package vn.com.abc.phongtro;

import android.content.DialogInterface;
import android.os.StrictMode;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.RadioButton;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import org.ksoap2.serialization.SoapObject;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

import vn.com.abc.entity.lvAdapter;
import vn.com.abc.entity.lvEntity;

public class ActivityKhachHang extends AppCompatActivity {

    private WebService ws = new WebService();
    private SoapObject tbKhachHang;
    private String[] cmbDisplay;
    private HashMap<Integer, String> cmbValue;

    @Override
    protected void onCreate(Bundle savedInstanceState) {

        // permits to make a HttpURLConnection
        if (android.os.Build.VERSION.SDK_INT > 9) {
            StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
            StrictMode.setThreadPolicy(policy);
        }

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_khach_hang);

        //Load Phòng
        SoapObject tableP = ws.GetDSPhong();
        if (tableP != null) {
            cmbDisplay = new String[tableP.getPropertyCount() + 1];
            cmbValue = new HashMap<Integer, String>();
            //dòng rỗng
            cmbValue.put(0, "");
            cmbDisplay[0] = "";
            for (int i = 0; i < tableP.getPropertyCount(); i++) {
                SoapObject obj = (SoapObject) tableP.getProperty(i);
                cmbValue.put(i + 1, obj.getProperty("ID").toString());
                cmbDisplay[i + 1] = obj.getProperty("Name").toString();
            }
            Spinner cmbPhong = (Spinner) findViewById(R.id.cmbPhong);
            ArrayAdapter<String> adapterP = new ArrayAdapter<String>(this, android.R.layout.simple_spinner_item, cmbDisplay);
            adapterP.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
            cmbPhong.setAdapter(adapterP);
        }

        Button btnThem = (Button) findViewById(R.id.btnThem);
        btnThem.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                try {
                    EditText txtHoTen = (EditText) findViewById(R.id.txtHoTen);
                    if (txtHoTen.getText().toString().matches("")) {
                        Toast.makeText(ActivityKhachHang.this, "Chưa nhập Họ Tên", Toast.LENGTH_SHORT).show();
                        return;
                    }

                    RadioButton radNu = (RadioButton) findViewById(R.id.radNu);
                    String GioiTinh = "1";
                    if (radNu.isChecked() == true)
                        GioiTinh = "0";

                    Spinner cmbPhong = (Spinner) findViewById(R.id.cmbPhong);
                    String MaPhong = "NULL";
                    if (cmbPhong.getSelectedItem().toString().matches("") == false)
                        MaPhong = cmbValue.get(cmbPhong.getSelectedItemPosition());

                    String resp = ws.ThemKhachHang(txtHoTen.getText().toString(), GioiTinh, MaPhong);
                    Toast.makeText(ActivityKhachHang.this, resp.toString(), Toast.LENGTH_SHORT).show();
                    onStart();
                } catch (Exception ex) {
                    Toast.makeText(ActivityKhachHang.this, ex.toString(), Toast.LENGTH_SHORT).show();
                }
            }
        });

        Button btnSua = (Button) findViewById(R.id.btnSua);
        btnSua.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                try {
                    EditText txtID = (EditText) findViewById(R.id.txtID);
                    if (txtID.getText().toString().matches("")) {
                        Toast.makeText(ActivityKhachHang.this, "Chưa chọn Khách Hàng", Toast.LENGTH_SHORT).show();
                        return;
                    }

                    EditText txtHoTen = (EditText) findViewById(R.id.txtHoTen);

                    RadioButton radNu = (RadioButton) findViewById(R.id.radNu);
                    String GioiTinh = "1";
                    if (radNu.isChecked() == true)
                        GioiTinh = "0";

                    Spinner cmbPhong = (Spinner) findViewById(R.id.cmbPhong);
                    String MaPhong = "NULL";
                    if (cmbPhong.getSelectedItem().toString().matches("") == false)
                        MaPhong = cmbValue.get(cmbPhong.getSelectedItemPosition());

                    String resp = ws.SuaKhachHang(txtID.getText().toString(), txtHoTen.getText().toString(), GioiTinh, MaPhong);
                    Toast.makeText(ActivityKhachHang.this, resp.toString(), Toast.LENGTH_SHORT).show();

                    onStart();
                } catch (Exception ex) {
                    Toast.makeText(ActivityKhachHang.this, ex.toString(), Toast.LENGTH_SHORT).show();
                }
            }
        });

        ListView listView = (ListView) findViewById(R.id.listView);

        listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                EditText txtID = (EditText) findViewById(R.id.txtID);
                EditText txtHoTen = (EditText) findViewById(R.id.txtHoTen);
                RadioButton radNam = (RadioButton) findViewById(R.id.radNam);
                RadioButton radNu = (RadioButton) findViewById(R.id.radNu);
                Spinner cmbPhong = (Spinner) findViewById(R.id.cmbPhong);

                String ID = ((TextView) view.findViewById(R.id.lvID)).getText().toString();
                if (tbKhachHang != null) {
                    for (int i = 0; i < tbKhachHang.getPropertyCount(); i++) {
                        SoapObject obj = (SoapObject) tbKhachHang.getProperty(i);
                        if (obj.getProperty("ID").toString() == ID) {
                            txtID.setText(obj.getProperty("ID").toString());
                            txtHoTen.setText(obj.getProperty("HoTen").toString());
                            if (Boolean.parseBoolean(obj.getProperty("GioiTinh").toString()) == true)
                                radNam.setChecked(true);
                            else
                                radNu.setChecked(true);

                            try {
                                Integer index = 0;
                                for (Map.Entry<Integer, String> entry : cmbValue.entrySet()) {
                                    if (entry.getValue().equals(obj.getProperty("MaPhong").toString())) {
                                        index = entry.getKey();
                                        break; //breaking because its one to one map
                                    }
                                }
                                cmbPhong.setSelection(index);
                            } catch (Exception ex) {
                                cmbPhong.setSelection(0);
                            }
                            break;
                        }
                    }
                }


            }
        });

        listView.setOnItemLongClickListener(new AdapterView.OnItemLongClickListener() {
            @Override
            public boolean onItemLongClick(AdapterView<?> parent, View view, int position, long id) {
                final String ID = ((TextView) view.findViewById(R.id.lvID)).getText().toString();

                AlertDialog.Builder alert = new AlertDialog.Builder(ActivityKhachHang.this);
                alert.setTitle("Delete entry");
                alert.setMessage("Are you sure you want to delete?");
                alert.setPositiveButton(android.R.string.yes, new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int which) {
                        // continue with delete
                        String resp = ws.XoaKhachHang(ID);
                        Toast.makeText(ActivityKhachHang.this, resp.toString(), Toast.LENGTH_SHORT).show();
                        onStart();
                    }
                });
                alert.setNegativeButton(android.R.string.no, new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int which) {
                        // close dialog
                        dialog.cancel();
                    }
                });
                alert.show();

                return true;
            }
        });

    }

    @Override
    protected void onStart() {
        // TODO Auto-generated method stub
        EditText txtID = (EditText) findViewById(R.id.txtID);
        txtID.setText("");
        EditText txtHoTen = (EditText) findViewById(R.id.txtHoTen);
        txtHoTen.setText("");
        RadioButton radNam = (RadioButton) findViewById(R.id.radNam);
        radNam.setChecked(true);


        //Load DataTable
        tbKhachHang = ws.GetDSKhachHang();
        ArrayList<lvEntity> list = new ArrayList<lvEntity>();

        if (tbKhachHang != null) {
            for (int i = 0; i < tbKhachHang.getPropertyCount(); i++) {
                SoapObject obj = (SoapObject) tbKhachHang.getProperty(i);
                lvEntity temp = new lvEntity();
                temp.setID(obj.getProperty("ID").toString());
                temp.setName(obj.getProperty("HoTen").toString());
                try {
                    String str = "";
                    if (Boolean.parseBoolean(obj.getProperty("GioiTinh").toString()) == true)
                        str += "Nam";
                    else
                        str += "Nữ";
                    str += " - Phòng:" + obj.getProperty("TenPhong").toString();
                    temp.setContent(str);
                } catch (Exception ex) {
                }

                list.add(temp);
            }

            ListView listView = (ListView) findViewById(R.id.listView);
            lvAdapter adapter = new lvAdapter(this, list);
            listView.setAdapter(adapter);
        }
        super.onStart();
    }

}