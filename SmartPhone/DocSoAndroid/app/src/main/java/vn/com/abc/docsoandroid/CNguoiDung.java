package vn.com.abc.docsoandroid;

import org.ksoap2.serialization.SoapObject;

import java.util.HashMap;

/**
 * Created by user on 23/08/2017.
 */

public class CNguoiDung {
    public static String MaND = "";
    public static String HoTen = "";
    public static String May = "";
    public static SoapObject tbDocSo = null;
    public static String[] cmbCodeDisplay;
    public static HashMap<Integer, String> cmbCodeValue;

    public static void Clear()
    {
        MaND="";
        HoTen="";
        May="";
        tbDocSo=null;
        cmbCodeDisplay=null;
        cmbCodeValue=null;
    }

}
