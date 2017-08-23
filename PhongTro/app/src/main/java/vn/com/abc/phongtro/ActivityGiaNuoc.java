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

public class ActivityGiaNuoc extends AppCompatActivity {

    private WebService ws = new WebService();
    private SoapObject tbGiaNuoc;

    @Override
    protected void onCreate(Bundle savedInstanceState) {

        // permits to make a HttpURLConnection
        if (android.os.Build.VERSION.SDK_INT > 9) {
            StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
            StrictMode.setThreadPolicy(policy);
        }

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_gia_nuoc);

        Button btnSua = (Button) findViewById(R.id.btnSua);
        btnSua.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                try {
                    EditText txtID = (EditText) findViewById(R.id.txtID);
                    if(txtID.getText().toString().matches(""))
                    {
                        Toast.makeText(ActivityGiaNuoc.this, "Chưa chọn Phòng", Toast.LENGTH_SHORT).show();
                        return;
                    }
                    EditText txtName = (EditText) findViewById(R.id.txtName);
                    EditText txtGiaTien = (EditText) findViewById(R.id.txtGiaTien);
                    String resp = ws.SuaGiaNuoc(txtID.getText().toString(),txtName.getText().toString(), txtGiaTien.getText().toString());
                    Toast.makeText(ActivityGiaNuoc.this, resp.toString(), Toast.LENGTH_SHORT).show();
                    onStart();
                } catch (Exception ex) {
                    Toast.makeText(ActivityGiaNuoc.this, ex.toString(), Toast.LENGTH_SHORT).show();
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

                String ID=((TextView) view.findViewById(R.id.lvID)).getText().toString();
                if (tbGiaNuoc != null) {
                    for (int i = 0; i < tbGiaNuoc.getPropertyCount(); i++) {
                        SoapObject obj = (SoapObject) tbGiaNuoc.getProperty(i);
                        if(obj.getProperty("ID").toString()==ID){
                            txtID.setText(obj.getProperty("ID").toString());
                            txtName.setText(obj.getProperty("Name").toString());
                            txtGiaTien.setText(obj.getProperty("GiaTien").toString());
                            break;
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

        tbGiaNuoc= ws.GetDSGiaNuoc();
        ArrayList<lvEntity> list = new ArrayList<lvEntity>();

        if (tbGiaNuoc != null) {
            for (int i = 0; i < tbGiaNuoc.getPropertyCount(); i++) {
                SoapObject obj = (SoapObject) tbGiaNuoc.getProperty(i);
                lvEntity temp = new lvEntity();
                temp.setID(obj.getProperty("ID").toString());
                temp.setName(obj.getProperty("Name").toString());
                temp.setContent(obj.getProperty("GiaTien").toString());
                list.add(temp);
            }

            ListView listView = (ListView) findViewById(R.id.listView);
            lvAdapter adapter = new lvAdapter(this, list);
            listView.setAdapter(adapter);
        }
        super.onStart();
    }
}
