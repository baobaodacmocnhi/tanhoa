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

public class ActivityHoaDon extends AppCompatActivity {

    private WebService ws = new WebService();
    private SoapObject tbHoaDon;
    private String[] cmbDisplay;
    private HashMap<Integer, String> cmbValue;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_hoa_don);

// permits to make a HttpURLConnection
        if (android.os.Build.VERSION.SDK_INT > 9) {
            StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
            StrictMode.setThreadPolicy(policy);
        }

        Button btnXem = (Button) findViewById(R.id.btnXem);
        btnXem.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                try {
                    Spinner cmbPhong = (Spinner) findViewById(R.id.cmbPhong);
                    if (cmbPhong.getSelectedItem().toString().matches("") == true) {
                        //Load DataTable
                        tbHoaDon = ws.GetDSHoaDon();
                        ArrayList<lvEntity> list = new ArrayList<lvEntity>();

                        if (tbHoaDon != null) {
                            for (int i = 0; i < tbHoaDon.getPropertyCount(); i++) {
                                SoapObject obj = (SoapObject) tbHoaDon.getProperty(i);
                                lvEntity temp = new lvEntity();
                                temp.setID(obj.getProperty("ID").toString());
                                temp.setName(obj.getProperty("TenPhong").toString());
                                String str = obj.getProperty("CreateDate").toString();
                                str += " - Tiêu Thụ Điện:" + obj.getProperty("TieuThuDien").toString();
                                str += " - Tiêu Thụ Nước:" + obj.getProperty("TieuThuNuoc").toString();
                                temp.setContent(str);
                                list.add(temp);
                            }

                            ListView listView = (ListView) findViewById(R.id.listView);
                            lvAdapter adapter = new lvAdapter(ActivityHoaDon.this, list);
                            listView.setAdapter(adapter);
                        }
                    } else {
                        //Load DataTable
                        tbHoaDon = ws.GetDSHoaDon(cmbValue.get(cmbPhong.getSelectedItemPosition()));
                        ArrayList<lvEntity> list = new ArrayList<lvEntity>();

                        if (tbHoaDon != null) {
                            for (int i = 0; i < tbHoaDon.getPropertyCount(); i++) {
                                SoapObject obj = (SoapObject) tbHoaDon.getProperty(i);
                                lvEntity temp = new lvEntity();
                                temp.setID(obj.getProperty("ID").toString());
                                temp.setName(obj.getProperty("TenPhong").toString());
                                String str = obj.getProperty("CreateDate").toString();
                                str += " - Tiêu Thụ Điện:" + obj.getProperty("TieuThuDien").toString();
                                str += " - Tiêu Thụ Nước:" + obj.getProperty("TieuThuNuoc").toString();
                                temp.setContent(str);
                                list.add(temp);
                            }

                            ListView listView = (ListView) findViewById(R.id.listView);
                            lvAdapter adapter = new lvAdapter(ActivityHoaDon.this, list);
                            listView.setAdapter(adapter);
                        }
                    }
                } catch (Exception ex) {
                    Toast.makeText(ActivityHoaDon.this, ex.toString(), Toast.LENGTH_SHORT).show();
                }
            }
        });

        final Button btnThem = (Button) findViewById(R.id.btnThem);
        btnThem.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                EditText txtID = (EditText) findViewById(R.id.txtID);
                EditText txtChiSoDien = (EditText) findViewById(R.id.txtChiSoDien);
                EditText txtChiSoNuoc = (EditText) findViewById(R.id.txtChiSoNuoc);
                Spinner cmbPhong = (Spinner) findViewById(R.id.cmbPhong);

                try {
                    if (cmbPhong.getSelectedItem().toString().matches("") == true) {
                        Toast.makeText(ActivityHoaDon.this, "Chưa chọn Phòng", Toast.LENGTH_SHORT).show();
                        return;
                    }
                    String MaPhong = cmbValue.get(cmbPhong.getSelectedItemPosition());

                    String resp = ws.ThemHoaDon(MaPhong, txtChiSoDien.getText().toString(), txtChiSoNuoc.getText().toString());
                    Toast.makeText(ActivityHoaDon.this, resp.toString(), Toast.LENGTH_SHORT).show();

                    Button btnXem = (Button) findViewById(R.id.btnXem);
                    btnXem.callOnClick();
                } catch (Exception ex) {
                    Toast.makeText(ActivityHoaDon.this, ex.toString(), Toast.LENGTH_SHORT).show();
                }
            }
        });

        Button btnSua = (Button) findViewById(R.id.btnSua);
        btnSua.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                EditText txtID = (EditText) findViewById(R.id.txtID);
                EditText txtChiSoDien = (EditText) findViewById(R.id.txtChiSoDien);
                EditText txtChiSoNuoc = (EditText) findViewById(R.id.txtChiSoNuoc);

                try {
                    String resp = ws.ThemHoaDon(txtID.getText().toString(), txtChiSoDien.getText().toString(), txtChiSoNuoc.getText().toString());
                    Toast.makeText(ActivityHoaDon.this, resp.toString(), Toast.LENGTH_SHORT).show();

                    Button btnXem = (Button) findViewById(R.id.btnXem);
                    btnXem.callOnClick();
                } catch (Exception ex) {
                    Toast.makeText(ActivityHoaDon.this, ex.toString(), Toast.LENGTH_SHORT).show();
                }
            }
        });

        ListView listView = (ListView) findViewById(R.id.listView);

        listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                EditText txtID = (EditText) findViewById(R.id.txtID);
                EditText txtChiSoDien = (EditText) findViewById(R.id.txtChiSoDien);
                EditText txtChiSoNuoc = (EditText) findViewById(R.id.txtChiSoNuoc);
                Spinner cmbPhong = (Spinner) findViewById(R.id.cmbPhong);

                String ID = ((TextView) view.findViewById(R.id.lvID)).getText().toString();
                if (tbHoaDon != null) {
                    for (int i = 0; i < tbHoaDon.getPropertyCount(); i++) {
                        SoapObject obj = (SoapObject) tbHoaDon.getProperty(i);
                        if (obj.getProperty("ID").toString() == ID) {
                            txtID.setText(obj.getProperty("ID").toString());
                            txtChiSoDien.setText(obj.getProperty("ChiSoDienNew").toString());
                            txtChiSoNuoc.setText(obj.getProperty("ChiSoNuocNew").toString());
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

                AlertDialog.Builder alert = new AlertDialog.Builder(ActivityHoaDon.this);
                alert.setTitle("Delete entry");
                alert.setMessage("Are you sure you want to delete?");
                alert.setPositiveButton(android.R.string.yes, new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int which) {
                        // continue with delete
                        String resp = ws.XoaHoaDon(ID);
                        Toast.makeText(ActivityHoaDon.this, resp.toString(), Toast.LENGTH_SHORT).show();
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
        EditText txtID = (EditText) findViewById(R.id.txtID);
        EditText txtChiSoDien = (EditText) findViewById(R.id.txtChiSoDien);
        EditText txtChiSoNuoc = (EditText) findViewById(R.id.txtChiSoNuoc);

        txtChiSoDien.setText("");
        txtID.setText("");
        txtChiSoNuoc.setText("");

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
        super.onStart();

    }
}