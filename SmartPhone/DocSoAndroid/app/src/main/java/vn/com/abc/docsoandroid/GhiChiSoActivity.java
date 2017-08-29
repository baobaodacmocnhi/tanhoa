package vn.com.abc.docsoandroid;

import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import org.ksoap2.serialization.PropertyInfo;
import org.ksoap2.serialization.SoapObject;

import java.util.Map;

public class GhiChiSoActivity extends Fragment {

    private View rootView;
    private Integer _index = 0;
    private String ID = "";
    private Spinner cmbCode;

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {

        rootView = inflater.inflate(R.layout.activity_ghi_chi_so, container, false);

        try {
            cmbCode = (Spinner) rootView.findViewById(R.id.cmbCode);
            ArrayAdapter<String> adapter = new ArrayAdapter<String>(getActivity(), android.R.layout.simple_spinner_item, CNguoiDung.cmbCodeDisplay);
            adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
            cmbCode.setAdapter(adapter);
        } catch (Exception ex) {
            Toast.makeText(getActivity(), ex.toString(), Toast.LENGTH_SHORT).show();
        }
        try {
//            Bundle bundle = getArguments();
//            ID = bundle.getString("ID");
            if (CNguoiDung.ID != "")
                GetDanhBo(ID);
        } catch (Exception ex) {
        }

        Button btnTruoc = (Button) rootView.findViewById(R.id.btnTruoc);
        btnTruoc.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (_index == 0) {
                    Toast.makeText(getActivity(), "Đầu Danh Sách", Toast.LENGTH_SHORT).show();
                    return;
                }
                _index--;
                GetDanhBo(_index);
            }
        });

        Button btnSau = (Button) rootView.findViewById(R.id.btnSau);
        btnSau.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (_index == CNguoiDung.tbDocSoFilter.getPropertyCount()) {
                    Toast.makeText(getActivity(), "Cuối Danh Sách", Toast.LENGTH_SHORT).show();
                    return;
                }
                _index++;
                GetDanhBo(_index);
            }
        });

        Button btnCapNhat = (Button) rootView.findViewById(R.id.btnCapNhat);
        btnCapNhat.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

            }
        });

        Button btnIn = (Button) rootView.findViewById(R.id.btnIn);
        btnIn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

            }
        });

        return rootView;
    }



    private void GetDanhBo(String ID) {
        try {
            for (int i = 0; i < CNguoiDung.tbDocSoFilter.getPropertyCount(); i++) {
                SoapObject obj = (SoapObject) CNguoiDung.tbDocSoFilter.getProperty(i);
                if (obj.getProperty("DocSoID").toString().matches(ID) == true) {
                    _index = i;
                    EditText txtDanhBo = (EditText) rootView.findViewById(R.id.txtDanhBo);
                    EditText txtMLT = (EditText) rootView.findViewById(R.id.txtMLT);
                    EditText txtHoTen = (EditText) rootView.findViewById(R.id.txtHoTen);
                    EditText txtDiaChi = (EditText) rootView.findViewById(R.id.txtDiaChi);
                    EditText txtGB = (EditText) rootView.findViewById(R.id.txtGB);
                    EditText txtDienThoai = (EditText) rootView.findViewById(R.id.txtDienThoai);
                    EditText txtSoThan = (EditText) rootView.findViewById(R.id.txtSoThan);
                    EditText txtDM = (EditText) rootView.findViewById(R.id.txtDM);
                    EditText txtVT = (EditText) rootView.findViewById(R.id.txtVT);
                    EditText txtCo = (EditText) rootView.findViewById(R.id.txtCo);
                    EditText txtHieu = (EditText) rootView.findViewById(R.id.txtHieu);
                    EditText txtCT = (EditText) rootView.findViewById(R.id.txtCT);
                    EditText txtTongTien = (EditText) rootView.findViewById(R.id.txtTongTien);
                    EditText txtTT = (EditText) rootView.findViewById(R.id.txtTT);
                    EditText txt3T = (EditText) rootView.findViewById(R.id.txt3T);
                    EditText txtCC = (EditText) rootView.findViewById(R.id.txtCC);
                    EditText txtCode3 = (EditText) rootView.findViewById(R.id.txtCode3);
                    EditText txtCode2 = (EditText) rootView.findViewById(R.id.txtCode2);
                    EditText txtCode1 = (EditText) rootView.findViewById(R.id.txtCode1);
                    EditText txtChiSo3 = (EditText) rootView.findViewById(R.id.txtChiSo3);
                    EditText txtChiSo2 = (EditText) rootView.findViewById(R.id.txtChiSo2);
                    EditText txtChiSo1 = (EditText) rootView.findViewById(R.id.txtChiSo1);
                    EditText txtTieuThu3 = (EditText) rootView.findViewById(R.id.txtTieuThu3);
                    EditText txtTieuThu2 = (EditText) rootView.findViewById(R.id.txtTieuThu2);
                    EditText txtTieuThu1 = (EditText) rootView.findViewById(R.id.txtTieuThu1);

                    EditText txtChiSo = (EditText) rootView.findViewById(R.id.txtChiSo);
                    EditText txtTieuThu = (EditText) rootView.findViewById(R.id.txtTieuThu);

                    String DanhBo = new StringBuilder(obj.getProperty("DanhBa").toString()).insert(obj.getProperty("DanhBa").toString().length() - 7, " ").toString();
                    DanhBo = new StringBuilder(DanhBo).insert(DanhBo.length() - 4, " ").toString();
                    txtDanhBo.setText(DanhBo);

                    String MLT = new StringBuilder(obj.getProperty("MLT1").toString()).insert(obj.getProperty("MLT1").toString().length() - 7, " ").toString();
                    MLT = new StringBuilder(MLT).insert(MLT.length() - 5, " ").toString();
                    txtMLT.setText(MLT);

//                    txtHoTen.setText(obj.getProperty("HoTen").toString());
                    txtDiaChi.setText(obj.getProperty("SoNhaCu").toString() + " " + obj.getProperty("Duong").toString());
                    txtGB.setText(obj.getProperty("GB").toString());
                    txtDienThoai.setText(obj.getProperty("SDT").toString());
                    txtSoThan.setText(obj.getProperty("SoThanCu").toString());
                    txtDM.setText(obj.getProperty("DM").toString());
                    txtVT.setText(obj.getProperty("ViTriCu").toString());
                    txtHieu.setText(obj.getProperty("HieuCu").toString());
                    txtCT.setText(obj.getProperty("ChiThanCu").toString());
                    txtTongTien.setText(obj.getProperty("TongTien").toString());
//                    txtTT.setText(obj.getProperty("CoCu").toString());
//                    txtCC.setText(obj.getProperty("CoCu").toString());
                    Integer TT = 0;//tiêu thụ
                    Integer TB = 0;//trung bình cộng
                    try {
                        txtCode3.setText(obj.getProperty("CodeCu3").toString());
                        txtChiSo3.setText(obj.getProperty("CSCu3").toString());
                        txtTieuThu3.setText(obj.getProperty("TieuThuCu3").toString());
                        TT += Integer.parseInt(obj.getProperty("TieuThuCu3").toString());
                        TB++;
                    } catch (Exception ex) {
                    }

                    try {
                        txtCode2.setText(obj.getProperty("CodeCu2").toString());
                        txtChiSo2.setText(obj.getProperty("CSCu2").toString());
                        txtTieuThu2.setText(obj.getProperty("TieuThuCu2").toString());
                        TT += Integer.parseInt(obj.getProperty("TieuThuCu2").toString());
                        TB++;
                    } catch (Exception ex) {
                    }

                    try {
                        txtCode1.setText(obj.getProperty("CodeCu").toString());
                        txtChiSo1.setText(obj.getProperty("CSCu").toString());
                        txtTieuThu1.setText(obj.getProperty("TieuThuCu").toString());
                        TT += Integer.parseInt(obj.getProperty("TieuThuCu").toString());
                        TB++;
                    } catch (Exception ex) {
                    }

                    TT = TT / TB;
                    txt3T.setText(TT.toString());

//                    try {
//                        Integer index = 0;
//                        for (Map.Entry<Integer, String> entry : CNguoiDung.cmbCodeValue.entrySet()) {
//                            if (entry.getValue().equals(obj.getProperty("CodeMoi").toString())) {
//                                index = entry.getKey();
//                                break; //breaking because its one to one map
//                            }
//                        }
//                        cmbCode.setSelection(index);
//                    } catch (Exception ex) {
//                        cmbCode.setSelection(0);
//                    }
                    txtChiSo.setText(obj.getProperty("CSMoi").toString());
                    txtTieuThu.setText(obj.getProperty("TieuThuMoi").toString());
                    break;
                }
            }
        } catch (Exception ex) {
            Toast.makeText(getActivity(), ex.toString(), Toast.LENGTH_SHORT).show();
        }

    }

    private void GetDanhBo(Integer position) {
        try {
            SoapObject obj = (SoapObject) CNguoiDung.tbDocSoFilter.getProperty(_index);
            _index = position;
            EditText txtDanhBo = (EditText) rootView.findViewById(R.id.txtDanhBo);
            EditText txtMLT = (EditText) rootView.findViewById(R.id.txtMLT);
            EditText txtHoTen = (EditText) rootView.findViewById(R.id.txtHoTen);
            EditText txtDiaChi = (EditText) rootView.findViewById(R.id.txtDiaChi);
            EditText txtGB = (EditText) rootView.findViewById(R.id.txtGB);
            EditText txtDienThoai = (EditText) rootView.findViewById(R.id.txtDienThoai);
            EditText txtSoThan = (EditText) rootView.findViewById(R.id.txtSoThan);
            EditText txtDM = (EditText) rootView.findViewById(R.id.txtDM);
            EditText txtVT = (EditText) rootView.findViewById(R.id.txtVT);
            EditText txtCo = (EditText) rootView.findViewById(R.id.txtCo);
            EditText txtHieu = (EditText) rootView.findViewById(R.id.txtHieu);
            EditText txtCT = (EditText) rootView.findViewById(R.id.txtCT);
            EditText txtTongTien = (EditText) rootView.findViewById(R.id.txtTongTien);
            EditText txtTT = (EditText) rootView.findViewById(R.id.txtTT);
            EditText txt3T = (EditText) rootView.findViewById(R.id.txt3T);
            EditText txtCC = (EditText) rootView.findViewById(R.id.txtCC);
            EditText txtCode3 = (EditText) rootView.findViewById(R.id.txtCode3);
            EditText txtCode2 = (EditText) rootView.findViewById(R.id.txtCode2);
            EditText txtCode1 = (EditText) rootView.findViewById(R.id.txtCode1);
            EditText txtChiSo3 = (EditText) rootView.findViewById(R.id.txtChiSo3);
            EditText txtChiSo2 = (EditText) rootView.findViewById(R.id.txtChiSo2);
            EditText txtChiSo1 = (EditText) rootView.findViewById(R.id.txtChiSo1);
            EditText txtTieuThu3 = (EditText) rootView.findViewById(R.id.txtTieuThu3);
            EditText txtTieuThu2 = (EditText) rootView.findViewById(R.id.txtTieuThu2);
            EditText txtTieuThu1 = (EditText) rootView.findViewById(R.id.txtTieuThu1);

            EditText txtChiSo = (EditText) rootView.findViewById(R.id.txtChiSo);
            EditText txtTieuThu = (EditText) rootView.findViewById(R.id.txtTieuThu);

            String DanhBo = new StringBuilder(obj.getProperty("DanhBa").toString()).insert(obj.getProperty("DanhBa").toString().length() - 7, " ").toString();
            DanhBo = new StringBuilder(DanhBo).insert(DanhBo.length() - 4, " ").toString();
            txtDanhBo.setText(DanhBo);

            String MLT = new StringBuilder(obj.getProperty("MLT1").toString()).insert(obj.getProperty("MLT1").toString().length() - 7, " ").toString();
            MLT = new StringBuilder(MLT).insert(MLT.length() - 5, " ").toString();
            txtMLT.setText(MLT);

//                    txtHoTen.setText(obj.getProperty("HoTen").toString());
            txtDiaChi.setText(obj.getProperty("SoNhaCu").toString() + " " + obj.getProperty("Duong").toString());
            txtGB.setText(obj.getProperty("GB").toString());
            txtDienThoai.setText(obj.getProperty("SDT").toString());
            txtSoThan.setText(obj.getProperty("SoThanCu").toString());
            txtDM.setText(obj.getProperty("DM").toString());
            txtVT.setText(obj.getProperty("ViTriCu").toString());
            txtHieu.setText(obj.getProperty("HieuCu").toString());
            txtCT.setText(obj.getProperty("ChiThanCu").toString());
            txtTongTien.setText(obj.getProperty("TongTien").toString());
//                    txtTT.setText(obj.getProperty("CoCu").toString());
//                    txtCC.setText(obj.getProperty("CoCu").toString());
            Integer TT = 0;//tiêu thụ
            Integer TB = 0;//trung bình cộng
            try {
                txtCode3.setText(obj.getProperty("CodeCu3").toString());
                txtChiSo3.setText(obj.getProperty("CSCu3").toString());
                txtTieuThu3.setText(obj.getProperty("TieuThuCu3").toString());
                TT += Integer.parseInt(obj.getProperty("TieuThuCu3").toString());
                TB++;
            } catch (Exception ex) {
            }

            try {
                txtCode2.setText(obj.getProperty("CodeCu2").toString());
                txtChiSo2.setText(obj.getProperty("CSCu2").toString());
                txtTieuThu2.setText(obj.getProperty("TieuThuCu2").toString());
                TT += Integer.parseInt(obj.getProperty("TieuThuCu2").toString());
                TB++;
            } catch (Exception ex) {
            }

            try {
                txtCode1.setText(obj.getProperty("CodeCu").toString());
                txtChiSo1.setText(obj.getProperty("CSCu").toString());
                txtTieuThu1.setText(obj.getProperty("TieuThuCu").toString());
                TT += Integer.parseInt(obj.getProperty("TieuThuCu").toString());
                TB++;
            } catch (Exception ex) {
            }

            TT = TT / TB;
            txt3T.setText(TT.toString());

//            try {
//                Integer index = 0;
//                for (Map.Entry<Integer, String> entry : CNguoiDung.cmbCodeValue.entrySet()) {
//                    if (entry.getValue().equals(obj.getProperty("CodeMoi").toString())) {
//                        index = entry.getKey();
//                        break; //breaking because its one to one map
//                    }
//                }
//                cmbCode.setSelection(index);
//            } catch (Exception ex) {
//                cmbCode.setSelection(0);
//            }
            txtChiSo.setText(obj.getProperty("CSMoi").toString());
            txtTieuThu.setText(obj.getProperty("TieuThuMoi").toString());
        } catch (Exception ex) {
            Toast.makeText(getActivity(), ex.toString(), Toast.LENGTH_SHORT).show();
        }

    }
}
