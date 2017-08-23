package vn.com.abc.docsoandroid;

import android.os.StrictMode;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import org.ksoap2.serialization.SoapObject;

public class DangNhapActivity extends AppCompatActivity {

    CWebService ws = new CWebService();

    @Override
    protected void onCreate(Bundle savedInstanceState) {

        // permits to make a HttpURLConnection
        if (android.os.Build.VERSION.SDK_INT > 9) {
            StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
            StrictMode.setThreadPolicy(policy);
        }

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_dang_nhap);

        Button btnDangNhap = (Button) findViewById(R.id.btnDangNhap);
        btnDangNhap.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                try {
                    EditText txtTaiKhoan = (EditText) findViewById(R.id.txtTaiKhoan);
                    EditText txtMatKhau = (EditText) findViewById(R.id.txtMatKhau);
                    if (txtTaiKhoan.getText().toString().matches("") || txtMatKhau.getText().toString().matches("")) {
                        Toast.makeText(DangNhapActivity.this, "Chưa nhập đủ thông tin", Toast.LENGTH_SHORT).show();
                        return;
                    }

                    SoapObject tbNguoiDung = ws.DangNhap(txtTaiKhoan.getText().toString(), txtMatKhau.getText().toString());
                    if (tbNguoiDung != null) {
                        SoapObject nguoidung=(SoapObject) tbNguoiDung.getProperty(0);
                        CNguoiDung.MaND= nguoidung.getProperty("MaND").toString();
                        CNguoiDung.HoTen= nguoidung.getProperty("HoTen").toString();
                        CNguoiDung.May= nguoidung.getProperty("May").toString();
                    } else {
                        Toast.makeText(DangNhapActivity.this, "Thất bại", Toast.LENGTH_SHORT).show();
                        return;
                    }
                } catch (Exception ex) {
                    Toast.makeText(DangNhapActivity.this, ex.toString(), Toast.LENGTH_SHORT).show();
                }
            }
        });
    }
}
