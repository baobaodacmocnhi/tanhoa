package vn.com.abc.docsoandroid;

import android.app.Activity;
import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        Button btnDangNhap = (Button) findViewById(R.id.btnDangNhap);
        btnDangNhap.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(MainActivity.this, DangNhapActivity.class);
                startActivityForResult(intent, 1);
            }
        });

        Button btnDanhSachDocSo = (Button) findViewById(R.id.btnDanhSachDocSo);
        btnDanhSachDocSo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(MainActivity.this, DanhSachDocSoActivity.class);
                startActivity(intent);
            }
        });

        Button btnDocSo = (Button) findViewById(R.id.btnDocSo);
        btnDocSo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(MainActivity.this, DocSoActivity.class);
                startActivity(intent);
            }
        });

        Button btnDangXuat = (Button) findViewById(R.id.btnDangXuat);
        btnDangXuat.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                CNguoiDung.Clear();
                Button btnDangNhap = (Button) findViewById(R.id.btnDangNhap);

                btnDangNhap.setEnabled(true);
                btnDangNhap.callOnClick();
            }
        });

        Button btnTest = (Button) findViewById(R.id.btnTest);
        btnTest.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(MainActivity.this, Test.class);
                startActivity(intent);
            }
        });
    }

    @Override
    protected void onStart() {
        super.onStart();
        if (CNguoiDung.MaND == "") {
            Button btnDangNhap = (Button) findViewById(R.id.btnDangNhap);

            btnDangNhap.callOnClick();
        }
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
//        super.onActivityResult(requestCode, resultCode, data);
        if (requestCode == 1) {
            if (resultCode == Activity.RESULT_OK) {
                Button btnDangNhap = (Button) findViewById(R.id.btnDangNhap);

                btnDangNhap.setEnabled(false);
            }
        }
    }
}
