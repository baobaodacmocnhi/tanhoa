package vn.com.abc.docsoandroid;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import org.ksoap2.serialization.SoapObject;

import java.util.ArrayList;

public class DanhSachDocSoActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_danh_sach_doc_so);

        try {
            Spinner cmbCode = (Spinner) findViewById(R.id.cmbCode);
            ArrayAdapter<String> adapter = new ArrayAdapter<String>(this, android.R.layout.simple_spinner_item, CNguoiDung.cmbCodeDisplay);
            adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
            cmbCode.setAdapter(adapter);
        } catch (Exception ex) {
            Toast.makeText(DanhSachDocSoActivity.this, ex.toString(), Toast.LENGTH_SHORT).show();
        }

        Button btnXem = (Button) findViewById(R.id.btnXem);
        btnXem.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                try {
                    if (CNguoiDung.tbDocSo != null) {
                        ArrayList<lstViewEntity> list = new ArrayList<lstViewEntity>();
                        for (int i = 0; i < CNguoiDung.tbDocSo.getPropertyCount(); i++) {
                            SoapObject obj = (SoapObject) CNguoiDung.tbDocSo.getProperty(i);
                            lstViewEntity temp = new lstViewEntity();
                            temp.setID(obj.getProperty("DocSoID").toString());

                            String DanhBo=new StringBuilder(obj.getProperty("DanhBa").toString()).insert(obj.getProperty("DanhBa").toString().length()-7, " ").toString();
                            DanhBo=new StringBuilder(DanhBo).insert(DanhBo.length()-4, " ").toString();
                            temp.setName1(DanhBo);

                            String MLT=new StringBuilder(obj.getProperty("MLT1").toString()).insert(obj.getProperty("MLT1").toString().length()-7, " ").toString();
                            MLT=new StringBuilder(MLT).insert(MLT.length()-5, " ").toString();
                            temp.setName2(MLT);

                            String content =" ĐC: "+obj.getProperty("SoNhaCu").toString()+" "+obj.getProperty("Duong").toString();
                            temp.setContent(content);

                            list.add(temp);
                        }

                        ListView lstView = (ListView) findViewById(R.id.lstView);
                        lstViewAdapter adapter = new lstViewAdapter(DanhSachDocSoActivity.this, list);
                        lstView.setAdapter(adapter);
                    }
                } catch (Exception ex) {
                    Toast.makeText(DanhSachDocSoActivity.this, ex.toString(), Toast.LENGTH_SHORT).show();
                }
            }
        });

        ListView lstView=(ListView)findViewById(R.id.lstView);
        lstView.setOnItemLongClickListener(new AdapterView.OnItemLongClickListener() {
            @Override
            public boolean onItemLongClick(AdapterView<?> parent, View view, int position, long id) {
                TextView ID=(TextView)findViewById(R.id.lvID);
                Toast.makeText(DanhSachDocSoActivity.this, ID.getText(), Toast.LENGTH_SHORT).show();
                return false;
            }
        });
    }
}
