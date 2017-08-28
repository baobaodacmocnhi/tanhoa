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

import org.ksoap2.serialization.SoapObject;

import java.util.ArrayList;

public class DanhSachDocSoActivity extends Fragment {

//    @Override
//    protected void onCreate(Bundle savedInstanceState) {
//        super.onCreate(savedInstanceState);
//        setContentView(R.layout.activity_doc_so);
//
//        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
//        setSupportActionBar(toolbar);
//
//        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
//
//        ViewPager viewPager = (ViewPager) findViewById(R.id.container);
//        setupViewPager(viewPager);
//
//        TabLayout tabLayout = (TabLayout) findViewById(R.id.tabs);
//        tabLayout.setupWithViewPager(viewPager);
//
//        toolbar.setNavigationOnClickListener(new View.OnClickListener() {
//            @Override
//            public void onClick(View v) {
//                finish();
//            }
//        });
//    }
//
//    private void setupViewPager(ViewPager viewPager) {
//        TabPagerAdapter adapter = new TabPagerAdapter(getSupportFragmentManager());
//        adapter.addFragment(new DanhSachDocSoActivity(), "Danh Sách");
//        adapter.addFragment(new GhiChiSoActivity(), "Ghi Chỉ Số");
//        viewPager.setAdapter(adapter);
//    }

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container, Bundle savedInstanceState) {

        final View rootView = inflater.inflate(R.layout.activity_danh_sach_doc_so, container, false);

        try {
            Spinner cmbCode = (Spinner) rootView.findViewById(R.id.cmbCode);
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
                        ArrayList<lstViewEntity> list = new ArrayList<lstViewEntity>();
                        for (int i = 0; i < CNguoiDung.tbDocSo.getPropertyCount(); i++) {
                            SoapObject obj = (SoapObject) CNguoiDung.tbDocSo.getProperty(i);
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

                    fragmentTransaction.replace(R.id.ghichisoxml, ghichiso);
                    fragmentTransaction.commit();

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


}
