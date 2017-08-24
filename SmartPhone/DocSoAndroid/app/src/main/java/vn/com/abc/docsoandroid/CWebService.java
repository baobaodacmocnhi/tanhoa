package vn.com.abc.docsoandroid;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.PropertyInfo;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

/**
 * Created by user on 16/08/2017.
 */

public class CWebService {

    private final String WSDL_TARGET_NAMESPACE = "http://tempuri.org/";
    private final String SOAP_ADDRESS = "http://113.161.88.180:1989/service.asmx";

    public CWebService() {
    }

    private String ExcuteNonReturn(SoapObject request, String SOAP_ACTION) {
        try {
            SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(
                    SoapEnvelope.VER11);
            envelope.dotNet = true;

            envelope.setOutputSoapObject(request);

            HttpTransportSE httpTransport = new HttpTransportSE(SOAP_ADDRESS);
            Object response = null;

            httpTransport.call(SOAP_ACTION, envelope);
            response = envelope.getResponse();
            if (Boolean.parseBoolean(response.toString()) == true)
                return "Thành Công";
            else
                return "Thất Bại";
        } catch (Exception exception) {
            return exception.toString();
        }
    }

    private SoapObject ExcuteReturnTable(SoapObject request, String SOAP_ACTION) {
        try {
            SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(
                    SoapEnvelope.VER11);
            envelope.dotNet = true;

            envelope.setOutputSoapObject(request);

            HttpTransportSE httpTransport = new HttpTransportSE(SOAP_ADDRESS);
            SoapObject response = null;

            httpTransport.call(SOAP_ACTION, envelope);
            response = (SoapObject) envelope.bodyIn;

            response = (SoapObject) response.getProperty(0);
            response = (SoapObject) response.getProperty(1);
            response = (SoapObject) response.getProperty(0);
            return response;
        } catch (Exception ex) {
            return null;
        }

    }

    public String CheckDangNhap(String TaiKhoan, String MatKhau) {
        String SOAP_ACTION = "http://tempuri.org/DS_CheckDangNhap";
        String OPERATION_NAME = "DS_CheckDangNhap";
        SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE, OPERATION_NAME);

//        PropertyInfo pi = new PropertyInfo();
//        pi.setName("TaiKhoan");
//        pi.setValue(TaiKhoan);
//        pi.setType(String.class);
//        request.addProperty(pi);
//
//        pi = new PropertyInfo();
//        pi.setName("MatKhau");
//        pi.setValue(MatKhau);
//        pi.setType(String.class);
//        request.addProperty(pi);

        return ExcuteNonReturn(request, SOAP_ACTION);
    }

    public SoapObject DangNhap(String TaiKhoan, String MatKhau) {
        String SOAP_ACTION = "http://tempuri.org/DS_DangNhap";
        String OPERATION_NAME = "DS_DangNhap";
        SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE, OPERATION_NAME);

        PropertyInfo pi = new PropertyInfo();
        pi.setName("TaiKhoan");
        pi.setValue(TaiKhoan);
        pi.setType(String.class);
        request.addProperty(pi);

        pi = new PropertyInfo();
        pi.setName("MatKhau");
        pi.setValue(MatKhau);
        pi.setType(String.class);
        request.addProperty(pi);

        return ExcuteReturnTable(request, SOAP_ACTION);
    }

    public SoapObject GetDSCode() {
        String SOAP_ACTION = "http://tempuri.org/DS_GetDSCode";
        String OPERATION_NAME = "DS_GetDSCode";
        SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE, OPERATION_NAME);

        return ExcuteReturnTable(request, SOAP_ACTION);
    }

    public SoapObject GetDSDocSo(String Nam, String Ky,String Dot, String May) {
        String SOAP_ACTION = "http://tempuri.org/DS_GetDSDocSo";
        String OPERATION_NAME = "DS_GetDSDocSo";
        SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE, OPERATION_NAME);

        PropertyInfo pi = new PropertyInfo();
        pi.setName("Nam");
        pi.setValue(Nam);
        pi.setType(String.class);
        request.addProperty(pi);

        pi = new PropertyInfo();
        pi.setName("Ky");
        pi.setValue(Ky);
        pi.setType(String.class);
        request.addProperty(pi);

        pi = new PropertyInfo();
        pi.setName("Dot");
        pi.setValue(Dot);
        pi.setType(String.class);
        request.addProperty(pi);

        pi = new PropertyInfo();
        pi.setName("May");
        pi.setValue(May);
        pi.setType(String.class);
        request.addProperty(pi);

        return ExcuteReturnTable(request, SOAP_ACTION);
    }

}
