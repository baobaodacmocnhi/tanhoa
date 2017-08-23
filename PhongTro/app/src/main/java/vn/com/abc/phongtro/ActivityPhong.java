package vn.com.abc.phongtro;

import android.os.StrictMode;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import org.ksoap2.serialization.SoapObject;

import java.util.ArrayList;

import vn.com.abc.entity.lvAdapter;
import vn.com.abc.entity.lvEntity;

public class ActivityPhong extends AppCompatActivity {

    private WebService ws = new WebService();
    private SoapObject tbPhong;

    @Override
    protected void onCreate(Bundle savedInstanceState) {

        // permits to make a HttpURLConnection
        if (android.os.Build.VERSION.SDK_INT > 9) {
            StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
            StrictMode.setThreadPolicy(policy);
        }
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_phong);

        Button btnSua = (Button) findViewById(R.id.btnSua);
        btnSua.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                try {
                    EditText txtID = (EditText) findViewById(R.id.txtID);
                    if (txtID.getText().toString().matches("")) {
                        Toast.makeText(ActivityPhong.this, "Chưa chọn Phòng", Toast.LENGTH_SHORT).show();
                        return;
                    }
                    EditText txtName = (EditText) findViewById(R.id.txtName);
                    EditText txtGiaTien = (EditText) findViewById(R.id.txtGiaTien);
                    EditText txtChiSoDien = (EditText) findViewById(R.id.txtChiSoDien);
                    EditText txtChiSoNuoc = (EditText) findViewById(R.id.txtChiSoNuoc);

                    String resp = ws.SuaPhong(txtID.getText().toString(), txtName.getText().toString(), txtGiaTien.getText().toString(), txtChiSoDien.getText().toString(), txtChiSoNuoc.getText().toString());
                    Toast.makeText(ActivityPhong.this, resp.toString(), Toast.LENGTH_SHORT).show();
                    onStart();
                } catch (Exception ex) {
                    Toast.makeText(ActivityPhong.this, ex.toString(), Toast.LENGTH_SHORT).show();
                }
            }
        });

        ListView listView = (ListView) findViewById(R.id.listView);

        listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                EditText txtID = (EditText) findViewById(R.id.txtID);
                EditText txtName = (EditText) findViewById(R.id.txtName);
                EditText txtGiaTien = (EditText) findViewById(R.id.txtGiaTien);
                EditText txtChiSoDien = (EditText) findViewById(R.id.txtChiSoDien);
                EditText txtChiSoNuoc = (EditText) findViewById(R.id.txtChiSoNuoc);

                String ID=((TextView) view.findViewById(R.id.lvID)).getText().toString();
                if (tbPhong != null) {
                    for (int i = 0; i < tbPhong.getPropertyCount(); i++) {
                        SoapObject obj = (SoapObject) tbPhong.getProperty(i);
                        if(obj.getProperty("ID").toString()==ID){
                            txtID.setText(obj.getProperty("ID").toString());
                            txtName.setText(obj.getProperty("Name").toString());
                            txtGiaTien.setText(obj.getProperty("GiaTien").toString());
                            txtChiSoDien.setText(obj.getProperty("ChiSoDien").toString());
                            txtChiSoNuoc.setText(obj.getProperty("ChiSoNuoc").toString());
                        }

                    }
                }

            }
        });
    }

    @Override
    protected void onStart() {
        EditText txtID = (EditText) findViewById(R.id.txtID);
        txtID.setText("");
        EditText txtName = (EditText) findViewById(R.id.txtName);
        txtName.setText("");
        EditText txtGiaTien = (EditText) findViewById(R.id.txtGiaTien);
        txtGiaTien.setText("");

        tbPhong = ws.GetDSPhong();
        ArrayList<lvEntity> list = new ArrayList<lvEntity>();

        if (tbPhong != null) {
            for (int i = 0; i < tbPhong.getPropertyCount(); i++) {
                SoapObject obj = (SoapObject) tbPhong.getProperty(i);
                lvEntity temp = new lvEntity();
                temp.setID(obj.getProperty("ID").toString());
                temp.setName(obj.getProperty("Name").toString());
                String str = obj.getProperty("GiaTien").toString();
                str += " - Chỉ Số Điện:" + obj.getProperty("ChiSoDien").toString();
                str += " - Chỉ Số Nước:" + obj.getProperty("ChiSoNuoc").toString();
                list.add(temp);
            }

            ListView listView = (ListView) findViewById(R.id.listView);
            lvAdapter adapter = new lvAdapter(this, list);
            listView.setAdapter(adapter);
        }
        super.onStart();
    }
}
