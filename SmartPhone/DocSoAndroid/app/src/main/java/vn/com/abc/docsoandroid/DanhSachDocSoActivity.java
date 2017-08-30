package vn.com.abc.docsoandroid;

import android.content.Context;
import android.support.annotation.Nullable;
import android.support.design.widget.TabLayout;
import android.support.v4.app.Fragment;
import android.os.Bundle;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentTransaction;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import org.ksoap2.serialization.PropertyInfo;
import org.ksoap2.serialization.SoapObject;

import java.util.ArrayList;

public class DanhSachDocSoActivity extends Fragment {

    private Spinner cmbCode;

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container, Bundle savedInstanceState) {

        final View rootView = inflater.inflate(R.layout.activity_danh_sach_doc_so, container, false);

        try {
            cmbCode = (Spinner) rootView.findViewById(R.id.cmbCode);
            ArrayAdapter<String> adapter = new ArrayAdapter<String>(getActivity(), android.R.layout.simple_spinner_item, CNguoiDung.cmbCodeDisplay);
            adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
            cmbCode.setAdapter(adapter);
        } catch (Exception ex) {
            Toast.makeText(getActivity(), ex.toString(), Toast.LENGTH_SHORT).show();
        }

        Button btnXem = (Button) rootView.findViewById(R.id.btnXem);
        btnXem.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                try {
                    if (CNguoiDung.tbDocSo != null) {
                        DanhSachDocSoFilter(cmbCode.getSelectedItem().toString());

                        ArrayList<lstViewEntity> list = new ArrayList<lstViewEntity>();
                        for (int i = 0; i < CNguoiDung.tbDocSoFilter.getPropertyCount(); i++) {
                            SoapObject obj = (SoapObject) CNguoiDung.tbDocSoFilter.getProperty(i);

                            lstViewEntity temp = new lstViewEntity();
                            temp.setID(obj.getProperty("DocSoID").toString());

                            String DanhBo = new StringBuilder(obj.getProperty("DanhBa").toString()).insert(obj.getProperty("DanhBa").toString().length() - 7, " ").toString();
                            DanhBo = new StringBuilder(DanhBo).insert(DanhBo.length() - 4, " ").toString();
                            temp.setName1(DanhBo);

                            String MLT = new StringBuilder(obj.getProperty("MLT1").toString()).insert(obj.getProperty("MLT1").toString().length() - 7, " ").toString();
                            MLT = new StringBuilder(MLT).insert(MLT.length() - 5, " ").toString();
                            temp.setName2(MLT);

                            String content = " ĐC: " + obj.getProperty("SoNhaCu").toString() + " " + obj.getProperty("Duong").toString();
                            temp.setContent(content);

                            list.add(temp);
                        }

                        ListView lstView = (ListView) rootView.findViewById(R.id.lstView);
                        lstViewAdapter adapter = new lstViewAdapter(getActivity(), list);
                        lstView.setAdapter(adapter);

                        TextView txtTongDB=(TextView)rootView.findViewById(R.id.txtTongDB);
                        txtTongDB.setText("Tổng: "+CNguoiDung.tbDocSoFilter.getPropertyCount()+" DB");
                    }
                } catch (Exception ex) {
                    Toast.makeText(getActivity(), ex.toString(), Toast.LENGTH_SHORT).show();
                }
            }
        });

        ListView lstView = (ListView) rootView.findViewById(R.id.lstView);
        lstView.setOnItemLongClickListener(new AdapterView.OnItemLongClickListener() {
            @Override
            public boolean onItemLongClick(AdapterView<?> parent, View view, int position, long id) {
                try {
                    TextView ID = (TextView) rootView.findViewById(R.id.lvID);

                    Bundle bundle = new Bundle();
                    bundle.putString("ID", ID.getText().toString());

                    FragmentManager fragmentManager = getActivity().getSupportFragmentManager();
                    FragmentTransaction fragmentTransaction = fragmentManager.beginTransaction();

                    GhiChiSoActivity ghichiso = new GhiChiSoActivity();
                    ghichiso.setArguments(bundle);

                    fragmentTransaction.addToBackStack(null);
                    fragmentTransaction.replace(R.id.ghichisolayout, ghichiso);
                    fragmentTransaction.commit();

//                    CNguoiDung.ID=ID.getText().toString();

//                    listener.onClickDanhSachDocSoFragment(ID.getText().toString());

                    TabLayout tabhost = (TabLayout) getActivity().findViewById(R.id.tabs);
                    tabhost.getTabAt(1).select();
                } catch (Exception ex) {
                    Toast.makeText(getActivity(), ex.toString(), Toast.LENGTH_SHORT).show();
                }

                return false;
            }
        });

        return rootView;
    }

    private void DanhSachDocSoFilter(String Code) {
        try {
            CNguoiDung.tbDocSoFilter = new SoapObject("DocSo", "tbDocSoFilter");
            if (Code == "Chưa Ghi")
                for (int i = 0; i < CNguoiDung.tbDocSo.getPropertyCount(); i++) {
                    SoapObject obj = (SoapObject) CNguoiDung.tbDocSo.getProperty(i);
                    if (obj.getProperty("TTDHNMoi").toString().matches("") == true)
                    {
                        SoapObject temp=new SoapObject("temp","");
                        PropertyInfo propertyInfoP=new PropertyInfo();
                        for (int j = 0; j < obj.getPropertyCount(); j++) {
                            PropertyInfo propertyInfo = new PropertyInfo();
                            obj.getPropertyInfo(j, propertyInfo);
                            temp.addProperty(propertyInfo.getName(), obj.getProperty(j));
                        }
                        propertyInfoP.setName("Table");
                        propertyInfoP.setValue(temp);
                        CNguoiDung.tbDocSoFilter.addProperty(propertyInfoP);
                    }

                }
            else if (Code == "Đã Ghi") {
                for (int i = 0; i < CNguoiDung.tbDocSo.getPropertyCount(); i++) {
                    SoapObject obj = (SoapObject) CNguoiDung.tbDocSo.getProperty(i);
                    if (obj.getProperty("TTDHNMoi").toString().matches("") == false) {
                        SoapObject temp=new SoapObject("temp","");
                        PropertyInfo propertyInfoP=new PropertyInfo();
                        for (int j = 0; j < obj.getPropertyCount(); j++) {
                            PropertyInfo propertyInfo = new PropertyInfo();
                            obj.getPropertyInfo(j, propertyInfo);
                            temp.addProperty(propertyInfo.getName(), obj.getProperty(j));
                        }
                        propertyInfoP.setName("Table");
                        propertyInfoP.setValue(temp);
                        CNguoiDung.tbDocSoFilter.addProperty(propertyInfoP);
                    }
                }
            }
            else
            {
                for (int i = 0; i < CNguoiDung.tbDocSo.getPropertyCount(); i++) {
                    SoapObject obj = (SoapObject) CNguoiDung.tbDocSo.getProperty(i);
                    if (obj.getProperty("TTDHNMoi").toString().matches(Code) == true) {
                        SoapObject temp=new SoapObject("temp","");
                        PropertyInfo propertyInfoP=new PropertyInfo();
                        for (int j = 0; j < obj.getPropertyCount(); j++) {
                            PropertyInfo propertyInfo = new PropertyInfo();
                            obj.getPropertyInfo(j, propertyInfo);
                            temp.addProperty(propertyInfo.getName(), obj.getProperty(j));
                        }
                        propertyInfoP.setName("Table");
                        propertyInfoP.setValue(temp);
                        CNguoiDung.tbDocSoFilter.addProperty(propertyInfoP);
                    }
                }
            }
        } catch (Exception ex) {
            Toast.makeText(getActivity(), ex.toString(), Toast.LENGTH_SHORT).show();
        }

    }

}
