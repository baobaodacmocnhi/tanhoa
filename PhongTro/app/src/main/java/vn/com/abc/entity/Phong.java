package vn.com.abc.entity;

/**
 * Created by user on 21/08/2017.
 */

public class Phong {
    private String ID;
    private String Name;
    private String GiaTien;
    private String ChiSoDien;
    private String ChiSoNuoc;

    public String getID() {
        return ID;
    }

    public void setID(String ID) {
        this.ID = ID;
    }

    public String getName() {
        return Name;
    }

    public void setName(String name) {
        Name = name;
    }

    public String getGiaTien() {
        return GiaTien;
    }

    public void setGiaTien(String giaTien) {
        GiaTien = giaTien;
    }

    public String getChiSoDien() {
        return ChiSoDien;
    }

    public void setChiSoDien(String chiSoDien) {
        ChiSoDien = chiSoDien;
    }

    public String getChiSoNuoc() {
        return ChiSoNuoc;
    }

    public void setChiSoNuoc(String chiSoNuoc) {
        ChiSoNuoc = chiSoNuoc;
    }

    public String getContent() {
        return GiaTien+" - "+ChiSoDien+" - "+ChiSoNuoc;
    }
}
