package vn.com.abc.phongtro;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.PropertyInfo;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

/**
 * Created by user on 16/08/2017.
 */

public class WebService {

    private final String WSDL_TARGET_NAMESPACE = "http://tempuri.org/";
    private final String SOAP_ADDRESS = "http://113.161.88.180:1989/service.asmx";

    public WebService() {
    }

    private String ExcuteNonReturn(SoapObject request, String SOAP_ACTION) {
        SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(
                SoapEnvelope.VER11);
        envelope.dotNet = true;

        envelope.setOutputSoapObject(request);

        HttpTransportSE httpTransport = new HttpTransportSE(SOAP_ADDRESS);
        Object response = null;
        try {
            httpTransport.call(SOAP_ACTION, envelope);
            response = envelope.getResponse();
        } catch (Exception exception) {
            response = exception.toString();
        }
        if (Boolean.parseBoolean(response.toString()) == true)
            return "Thành Công";
        else
            return "Thất Bại";
    }

    private SoapObject ExcuteReturnTable(SoapObject request, String SOAP_ACTION) {
        SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(
                SoapEnvelope.VER11);
        envelope.dotNet = true;

        envelope.setOutputSoapObject(request);

        HttpTransportSE httpTransport = new HttpTransportSE(SOAP_ADDRESS);
        SoapObject response = null;
        try {
            httpTransport.call(SOAP_ACTION, envelope);
            response = (SoapObject) envelope.bodyIn;
        } catch (Exception exception) {
        }
        response = (SoapObject) response.getProperty(0);
        response = (SoapObject) response.getProperty(1);
        try {
            response = (SoapObject) response.getProperty(0);
        } catch (Exception ex) {
            return null;
        }
        return response;
    }

    public String ThemKhachHang(String HoTen, String GioiTinh, String MaPhong) {
        String SOAP_ACTION = "http://tempuri.org/ThemKhachHang";
        String OPERATION_NAME = "ThemKhachHang";
        SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE, OPERATION_NAME);

        PropertyInfo pi = new PropertyInfo();
        pi.setName("HoTen");
        pi.setValue(HoTen);
        pi.setType(String.class);
        request.addProperty(pi);

        pi = new PropertyInfo();
        pi.setName("GioiTinh");
        pi.setValue(GioiTinh);
        pi.setType(String.class);
        request.addProperty(pi);

        pi = new PropertyInfo();
        pi.setName("MaPhong");
        pi.setValue(MaPhong);
        pi.setType(String.class);
        request.addProperty(pi);

        return ExcuteNonReturn(request, SOAP_ACTION);
    }

    public String SuaKhachHang(String ID, String HoTen, String GioiTinh, String MaPhong) {
        String SOAP_ACTION = "http://tempuri.org/SuaKhachHang";
        String OPERATION_NAME = "SuaKhachHang";
        SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE, OPERATION_NAME);

        PropertyInfo pi = new PropertyInfo();

        pi.setName("ID");
        pi.setValue(ID);
        pi.setType(String.class);
        request.addProperty(pi);

        pi = new PropertyInfo();
        pi.setName("HoTen");
        pi.setValue(HoTen);
        pi.setType(String.class);
        request.addProperty(pi);

        pi = new PropertyInfo();
        pi.setName("GioiTinh");
        pi.setValue(GioiTinh);
        pi.setType(String.class);
        request.addProperty(pi);

        pi = new PropertyInfo();
        pi.setName("MaPhong");
        pi.setValue(MaPhong);
        pi.setType(String.class);
        request.addProperty(pi);

        return ExcuteNonReturn(request, SOAP_ACTION);
    }

    public String XoaKhachHang(String ID) {
        String SOAP_ACTION = "http://tempuri.org/XoaKhachHang";
        String OPERATION_NAME = "XoaKhachHang";
        SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE, OPERATION_NAME);

        PropertyInfo pi = new PropertyInfo();
        pi.setName("ID");
        pi.setValue(ID);
        pi.setType(String.class);
        request.addProperty(pi);

        return ExcuteNonReturn(request, SOAP_ACTION);
    }

    public SoapObject GetDSKhachHang() {
        String SOAP_ACTION = "http://tempuri.org/GetDSKhachHang";
        String OPERATION_NAME = "GetDSKhachHang";
        SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE, OPERATION_NAME);

        return ExcuteReturnTable(request, SOAP_ACTION);
    }

    public String SuaPhong(String ID, String Name, String GiaTien, String SoNKNuoc,String ChiSoDien, String ChiSoNuoc) {
        String SOAP_ACTION = "http://tempuri.org/SuaPhong";
        String OPERATION_NAME = "SuaPhong";
        SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE, OPERATION_NAME);

        PropertyInfo pi = new PropertyInfo();

        pi.setName("ID");
        pi.setValue(ID);
        pi.setType(String.class);
        request.addProperty(pi);

        pi = new PropertyInfo();
        pi.setName("Name");
        pi.setValue(Name);
        pi.setType(String.class);
        request.addProperty(pi);

        pi = new PropertyInfo();
        pi.setName("GiaTien");
        pi.setValue(GiaTien);
        pi.setType(String.class);
        request.addProperty(pi);

        pi = new PropertyInfo();
        pi.setName("SoNKNuoc");
        pi.setValue(SoNKNuoc);
        pi.setType(String.class);
        request.addProperty(pi);

        pi = new PropertyInfo();
        pi.setName("ChiSoDien");
        pi.setValue(ChiSoDien);
        pi.setType(String.class);
        request.addProperty(pi);

        pi = new PropertyInfo();
        pi.setName("ChiSoNuoc");
        pi.setValue(ChiSoNuoc);
        pi.setType(String.class);
        request.addProperty(pi);

        return ExcuteNonReturn(request, SOAP_ACTION);
    }

    public SoapObject GetDSPhong() {
        String SOAP_ACTION = "http://tempuri.org/GetDSPhong";
        String OPERATION_NAME = "GetDSPhong";
        SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE, OPERATION_NAME);

        return ExcuteReturnTable(request, SOAP_ACTION);
    }

    public String SuaGiaDien(String ID, String Name, String GiaTien) {
        String SOAP_ACTION = "http://tempuri.org/SuaGiaDien";
        String OPERATION_NAME = "SuaGiaDien";
        SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE, OPERATION_NAME);

        PropertyInfo pi = new PropertyInfo();

        pi.setName("ID");
        pi.setValue(ID);
        pi.setType(String.class);
        request.addProperty(pi);

        pi = new PropertyInfo();
        pi.setName("Name");
        pi.setValue(Name);
        pi.setType(String.class);
        request.addProperty(pi);

        pi = new PropertyInfo();
        pi.setName("GiaTien");
        pi.setValue(GiaTien);
        pi.setType(String.class);
        request.addProperty(pi);

        return ExcuteNonReturn(request, SOAP_ACTION);
    }

    public SoapObject GetDSGiaDien() {
        String SOAP_ACTION = "http://tempuri.org/GetDSGiaDien";
        String OPERATION_NAME = "GetDSGiaDien";
        SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE, OPERATION_NAME);

        return ExcuteReturnTable(request, SOAP_ACTION);
    }

    public String SuaGiaNuoc(String ID, String Name, String GiaTien) {
        String SOAP_ACTION = "http://tempuri.org/SuaGiaNuoc";
        String OPERATION_NAME = "SuaGiaNuoc";
        SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE, OPERATION_NAME);

        PropertyInfo pi = new PropertyInfo();

        pi.setName("ID");
        pi.setValue(ID);
        pi.setType(String.class);
        request.addProperty(pi);

        pi = new PropertyInfo();
        pi.setName("Name");
        pi.setValue(Name);
        pi.setType(String.class);
        request.addProperty(pi);

        pi = new PropertyInfo();
        pi.setName("GiaTien");
        pi.setValue(GiaTien);
        pi.setType(String.class);
        request.addProperty(pi);

        return ExcuteNonReturn(request, SOAP_ACTION);
    }

    public SoapObject GetDSGiaNuoc() {
        String SOAP_ACTION = "http://tempuri.org/GetDSGiaNuoc";
        String OPERATION_NAME = "GetDSGiaNuoc";
        SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE, OPERATION_NAME);

        return ExcuteReturnTable(request, SOAP_ACTION);
    }

    public String ThemHoaDon(String MaPhong, String ChiSoDien, String ChiSoNuoc) {
        String SOAP_ACTION = "http://tempuri.org/ThemHoaDon";
        String OPERATION_NAME = "ThemHoaDon";
        SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE, OPERATION_NAME);

        PropertyInfo pi = new PropertyInfo();
        pi.setName("MaPhong");
        pi.setValue(MaPhong);
        pi.setType(String.class);
        request.addProperty(pi);

        pi = new PropertyInfo();
        pi.setName("ChiSoDien");
        pi.setValue(ChiSoDien);
        pi.setType(String.class);
        request.addProperty(pi);

        pi = new PropertyInfo();
        pi.setName("ChiSoNuoc");
        pi.setValue(ChiSoNuoc);
        pi.setType(String.class);
        request.addProperty(pi);

        return ExcuteNonReturn(request, SOAP_ACTION);
    }

    public String SuaHoaDon(String ID, String ChiSoDien, String ChiSoNuoc) {
        String SOAP_ACTION = "http://tempuri.org/SuaHoaDon";
        String OPERATION_NAME = "SuaHoaDon";
        SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE, OPERATION_NAME);

        PropertyInfo pi = new PropertyInfo();
        pi.setName("ID");
        pi.setValue(ID);
        pi.setType(String.class);
        request.addProperty(pi);

        pi = new PropertyInfo();
        pi.setName("ChiSoDien");
        pi.setValue(ChiSoDien);
        pi.setType(String.class);
        request.addProperty(pi);

        pi = new PropertyInfo();
        pi.setName("ChiSoNuoc");
        pi.setValue(ChiSoNuoc);
        pi.setType(String.class);
        request.addProperty(pi);

        return ExcuteNonReturn(request, SOAP_ACTION);
    }

    public String XoaHoaDon(String ID) {
        String SOAP_ACTION = "http://tempuri.org/XoaHoaDon";
        String OPERATION_NAME = "XoaHoaDon";
        SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE, OPERATION_NAME);

        PropertyInfo pi = new PropertyInfo();
        pi.setName("ID");
        pi.setValue(ID);
        pi.setType(String.class);
        request.addProperty(pi);

        return ExcuteNonReturn(request, SOAP_ACTION);
    }

    public SoapObject GetDSHoaDon() {
        String SOAP_ACTION = "http://tempuri.org/GetDSHoaDonBB";
        String OPERATION_NAME = "GetDSHoaDonBB";
        SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE, OPERATION_NAME);

        return ExcuteReturnTable(request, SOAP_ACTION);
    }

    public SoapObject GetDSHoaDon(String MaPhong) {
        String SOAP_ACTION = "http://tempuri.org/GetDSHoaDonBBByMaPhong";
        String OPERATION_NAME = "GetDSHoaDonBBByMaPhong";
        SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE, OPERATION_NAME);

        PropertyInfo pi = new PropertyInfo();
        pi.setName("MaPhong");
        pi.setValue(MaPhong);
        pi.setType(String.class);
        request.addProperty(pi);

        return ExcuteReturnTable(request, SOAP_ACTION);
    }

}
