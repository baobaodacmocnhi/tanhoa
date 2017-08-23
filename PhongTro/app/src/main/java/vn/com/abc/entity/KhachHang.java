package vn.com.abc.entity;

/**
 * Created by user on 21/08/2017.
 */

public class KhachHang {

    private String ID;
    private String HoTen;
    private Boolean GioiTinh;
    private String MaPhong;

    public String getID() {
        return ID;
    }

    public void setID(String ID) {
        this.ID = ID;
    }

    public String getHoTen() {
        return HoTen;
    }

    public void setHoTen(String hoTen) {
        HoTen = hoTen;
    }

    public Boolean getGioiTinh() {
        return GioiTinh;
    }

    public void setGioiTinh(Boolean gioiTinh) {
        GioiTinh = gioiTinh;
    }

    public String getMaPhong() {
        return MaPhong;
    }

    public void setMaPhong(String maPhong) {
        MaPhong = maPhong;
    }

//    public KhachHang() {
//        ID = "";
//        HoTen = "";
//        GioiTinh = true;
//        MaPhong = "";
//    }

    public String getContent() {
        return GioiTinh+" - "+MaPhong;
    }

}
