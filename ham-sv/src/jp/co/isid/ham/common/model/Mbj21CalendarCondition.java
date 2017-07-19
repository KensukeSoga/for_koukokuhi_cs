package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * ƒJƒŒƒ“ƒ_[ƒ}ƒXƒ^ŒŸõğŒ
 * </P>
 * <P>
 * <B>C³—š—ğ</B><BR>
 * EV‹Kì¬(2012/11/29 VHAMƒ`[ƒ€)<BR>
 * </P>
 * @author VHAMƒ`[ƒ€
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj21CalendarCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ƒf[ƒ^‹æ•ª */
    private String _datakbn = null;

    /** ƒJƒŒƒ“ƒ_”NŒ */
    private String _calendarym = null;

    /** ŠY“–Œ‚Ì1“ú */
    private String _gaitoum1 = null;

    /** ŠY“–Œ‚Ì2“ú */
    private String _gaitoum2 = null;

    /** ŠY“–Œ‚Ì3“ú */
    private String _gaitoum3 = null;

    /** ŠY“–Œ‚Ì4“ú */
    private String _gaitoum4 = null;

    /** ŠY“–Œ‚Ì5“ú */
    private String _gaitoum5 = null;

    /** ŠY“–Œ‚Ì6“ú */
    private String _gaitoum6 = null;

    /** ŠY“–Œ‚Ì7“ú */
    private String _gaitoum7 = null;

    /** ŠY“–Œ‚Ì8“ú */
    private String _gaitoum8 = null;

    /** ŠY“–Œ‚Ì9“ú */
    private String _gaitoum9 = null;

    /** ŠY“–Œ‚Ì10“ú */
    private String _gaitoum10 = null;

    /** ŠY“–Œ‚Ì11“ú */
    private String _gaitoum11 = null;

    /** ŠY“–Œ‚Ì12“ú */
    private String _gaitoum12 = null;

    /** ŠY“–Œ‚Ì13“ú */
    private String _gaitoum13 = null;

    /** ŠY“–Œ‚Ì14“ú */
    private String _gaitoum14 = null;

    /** ŠY“–Œ‚Ì15“ú */
    private String _gaitoum15 = null;

    /** ŠY“–Œ‚Ì16“ú */
    private String _gaitoum16 = null;

    /** ŠY“–Œ‚Ì17“ú */
    private String _gaitoum17 = null;

    /** ŠY“–Œ‚Ì18“ú */
    private String _gaitoum18 = null;

    /** ŠY“–Œ‚Ì19“ú */
    private String _gaitoum19 = null;

    /** ŠY“–Œ‚Ì20“ú */
    private String _gaitoum20 = null;

    /** ŠY“–Œ‚Ì21“ú */
    private String _gaitoum21 = null;

    /** ŠY“–Œ‚Ì22“ú */
    private String _gaitoum22 = null;

    /** ŠY“–Œ‚Ì23“ú */
    private String _gaitoum23 = null;

    /** ŠY“–Œ‚Ì24“ú */
    private String _gaitoum24 = null;

    /** ŠY“–Œ‚Ì25“ú */
    private String _gaitoum25 = null;

    /** ŠY“–Œ‚Ì26“ú */
    private String _gaitoum26 = null;

    /** ŠY“–Œ‚Ì27“ú */
    private String _gaitoum27 = null;

    /** ŠY“–Œ‚Ì28“ú */
    private String _gaitoum28 = null;

    /** ŠY“–Œ‚Ì29“ú */
    private String _gaitoum29 = null;

    /** ŠY“–Œ‚Ì30“ú */
    private String _gaitoum30 = null;

    /** ŠY“–Œ‚Ì31“ú */
    private String _gaitoum31 = null;

    /** ƒf[ƒ^XV“ú */
    private Date _upddate = null;

    /** ƒf[ƒ^XVÒ */
    private String _updnm = null;

    /** XVƒvƒƒOƒ‰ƒ€ */
    private String _updapl = null;

    /** XV’S“–ÒID */
    private String _updid = null;

    /**
     * ƒfƒtƒHƒ‹ƒgƒRƒ“ƒXƒgƒ‰ƒNƒ^
     */
    public Mbj21CalendarCondition() {
    }

    /**
     * ƒf[ƒ^‹æ•ª‚ğæ“¾‚·‚é
     *
     * @return ƒf[ƒ^‹æ•ª
     */
    public String getDatakbn() {
        return _datakbn;
    }

    /**
     * ƒf[ƒ^‹æ•ª‚ğİ’è‚·‚é
     *
     * @param datakbn ƒf[ƒ^‹æ•ª
     */
    public void setDatakbn(String datakbn) {
        this._datakbn = datakbn;
    }

    /**
     * ƒJƒŒƒ“ƒ_”NŒ‚ğæ“¾‚·‚é
     *
     * @return ƒJƒŒƒ“ƒ_”NŒ
     */
    public String getCalendarym() {
        return _calendarym;
    }

    /**
     * ƒJƒŒƒ“ƒ_”NŒ‚ğİ’è‚·‚é
     *
     * @param calendarym ƒJƒŒƒ“ƒ_”NŒ
     */
    public void setCalendarym(String calendarym) {
        this._calendarym = calendarym;
    }

    /**
     * ŠY“–Œ‚Ì1“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì1“ú
     */
    public String getGaitoum1() {
        return _gaitoum1;
    }

    /**
     * ŠY“–Œ‚Ì1“ú‚ğİ’è‚·‚é
     *
     * @param gaitoum1 ŠY“–Œ‚Ì1“ú
     */
    public void setGaitoum1(String gaitoum1) {
        this._gaitoum1 = gaitoum1;
    }

    /**
     * ŠY“–Œ‚Ì2“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì2“ú
     */
    public String getGaitoum2() {
        return _gaitoum2;
    }

    /**
     * ŠY“–Œ‚Ì2“ú‚ğİ’è‚·‚é
     *
     * @param gaitoum2 ŠY“–Œ‚Ì2“ú
     */
    public void setGaitoum2(String gaitoum2) {
        this._gaitoum2 = gaitoum2;
    }

    /**
     * ŠY“–Œ‚Ì3“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì3“ú
     */
    public String getGaitoum3() {
        return _gaitoum3;
    }

    /**
     * ŠY“–Œ‚Ì3“ú‚ğİ’è‚·‚é
     *
     * @param gaitoum3 ŠY“–Œ‚Ì3“ú
     */
    public void setGaitoum3(String gaitoum3) {
        this._gaitoum3 = gaitoum3;
    }

    /**
     * ŠY“–Œ‚Ì4“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì4“ú
     */
    public String getGaitoum4() {
        return _gaitoum4;
    }

    /**
     * ŠY“–Œ‚Ì4“ú‚ğİ’è‚·‚é
     *
     * @param gaitoum4 ŠY“–Œ‚Ì4“ú
     */
    public void setGaitoum4(String gaitoum4) {
        this._gaitoum4 = gaitoum4;
    }

    /**
     * ŠY“–Œ‚Ì5“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì5“ú
     */
    public String getGaitoum5() {
        return _gaitoum5;
    }

    /**
     * ŠY“–Œ‚Ì5“ú‚ğİ’è‚·‚é
     *
     * @param gaitoum5 ŠY“–Œ‚Ì5“ú
     */
    public void setGaitoum5(String gaitoum5) {
        this._gaitoum5 = gaitoum5;
    }

    /**
     * ŠY“–Œ‚Ì6“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì6“ú
     */
    public String getGaitoum6() {
        return _gaitoum6;
    }

    /**
     * ŠY“–Œ‚Ì6“ú‚ğİ’è‚·‚é
     *
     * @param gaitoum6 ŠY“–Œ‚Ì6“ú
     */
    public void setGaitoum6(String gaitoum6) {
        this._gaitoum6 = gaitoum6;
    }

    /**
     * ŠY“–Œ‚Ì7“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì7“ú
     */
    public String getGaitoum7() {
        return _gaitoum7;
    }

    /**
     * ŠY“–Œ‚Ì7“ú‚ğİ’è‚·‚é
     *
     * @param gaitoum7 ŠY“–Œ‚Ì7“ú
     */
    public void setGaitoum7(String gaitoum7) {
        this._gaitoum7 = gaitoum7;
    }

    /**
     * ŠY“–Œ‚Ì8“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì8“ú
     */
    public String getGaitoum8() {
        return _gaitoum8;
    }

    /**
     * ŠY“–Œ‚Ì8“ú‚ğİ’è‚·‚é
     *
     * @param gaitoum8 ŠY“–Œ‚Ì8“ú
     */
    public void setGaitoum8(String gaitoum8) {
        this._gaitoum8 = gaitoum8;
    }

    /**
     * ŠY“–Œ‚Ì9“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì9“ú
     */
    public String getGaitoum9() {
        return _gaitoum9;
    }

    /**
     * ŠY“–Œ‚Ì9“ú‚ğİ’è‚·‚é
     *
     * @param gaitoum9 ŠY“–Œ‚Ì9“ú
     */
    public void setGaitoum9(String gaitoum9) {
        this._gaitoum9 = gaitoum9;
    }

    /**
     * ŠY“–Œ‚Ì10“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì10“ú
     */
    public String getGaitoum10() {
        return _gaitoum10;
    }

    /**
     * ŠY“–Œ‚Ì10“ú‚ğİ’è‚·‚é
     *
     * @param gaitoum10 ŠY“–Œ‚Ì10“ú
     */
    public void setGaitoum10(String gaitoum10) {
        this._gaitoum10 = gaitoum10;
    }

    /**
     * ŠY“–Œ‚Ì11“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì11“ú
     */
    public String getGaitoum11() {
        return _gaitoum11;
    }

    /**
     * ŠY“–Œ‚Ì11“ú‚ğİ’è‚·‚é
     *
     * @param gaitoum11 ŠY“–Œ‚Ì11“ú
     */
    public void setGaitoum11(String gaitoum11) {
        this._gaitoum11 = gaitoum11;
    }

    /**
     * ŠY“–Œ‚Ì12“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì12“ú
     */
    public String getGaitoum12() {
        return _gaitoum12;
    }

    /**
     * ŠY“–Œ‚Ì12“ú‚ğİ’è‚·‚é
     *
     * @param gaitoum12 ŠY“–Œ‚Ì12“ú
     */
    public void setGaitoum12(String gaitoum12) {
        this._gaitoum12 = gaitoum12;
    }

    /**
     * ŠY“–Œ‚Ì13“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì13“ú
     */
    public String getGaitoum13() {
        return _gaitoum13;
    }

    /**
     * ŠY“–Œ‚Ì13“ú‚ğİ’è‚·‚é
     *
     * @param gaitoum13 ŠY“–Œ‚Ì13“ú
     */
    public void setGaitoum13(String gaitoum13) {
        this._gaitoum13 = gaitoum13;
    }

    /**
     * ŠY“–Œ‚Ì14“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì14“ú
     */
    public String getGaitoum14() {
        return _gaitoum14;
    }

    /**
     * ŠY“–Œ‚Ì14“ú‚ğİ’è‚·‚é
     *
     * @param gaitoum14 ŠY“–Œ‚Ì14“ú
     */
    public void setGaitoum14(String gaitoum14) {
        this._gaitoum14 = gaitoum14;
    }

    /**
     * ŠY“–Œ‚Ì15“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì15“ú
     */
    public String getGaitoum15() {
        return _gaitoum15;
    }

    /**
     * ŠY“–Œ‚Ì15“ú‚ğİ’è‚·‚é
     *
     * @param gaitoum15 ŠY“–Œ‚Ì15“ú
     */
    public void setGaitoum15(String gaitoum15) {
        this._gaitoum15 = gaitoum15;
    }

    /**
     * ŠY“–Œ‚Ì16“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì16“ú
     */
    public String getGaitoum16() {
        return _gaitoum16;
    }

    /**
     * ŠY“–Œ‚Ì16“ú‚ğİ’è‚·‚é
     *
     * @param gaitoum16 ŠY“–Œ‚Ì16“ú
     */
    public void setGaitoum16(String gaitoum16) {
        this._gaitoum16 = gaitoum16;
    }

    /**
     * ŠY“–Œ‚Ì17“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì17“ú
     */
    public String getGaitoum17() {
        return _gaitoum17;
    }

    /**
     * ŠY“–Œ‚Ì17“ú‚ğİ’è‚·‚é
     *
     * @param gaitoum17 ŠY“–Œ‚Ì17“ú
     */
    public void setGaitoum17(String gaitoum17) {
        this._gaitoum17 = gaitoum17;
    }

    /**
     * ŠY“–Œ‚Ì18“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì18“ú
     */
    public String getGaitoum18() {
        return _gaitoum18;
    }

    /**
     * ŠY“–Œ‚Ì18“ú‚ğİ’è‚·‚é
     *
     * @param gaitoum18 ŠY“–Œ‚Ì18“ú
     */
    public void setGaitoum18(String gaitoum18) {
        this._gaitoum18 = gaitoum18;
    }

    /**
     * ŠY“–Œ‚Ì19“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì19“ú
     */
    public String getGaitoum19() {
        return _gaitoum19;
    }

    /**
     * ŠY“–Œ‚Ì19“ú‚ğİ’è‚·‚é
     *
     * @param gaitoum19 ŠY“–Œ‚Ì19“ú
     */
    public void setGaitoum19(String gaitoum19) {
        this._gaitoum19 = gaitoum19;
    }

    /**
     * ŠY“–Œ‚Ì20“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì20“ú
     */
    public String getGaitoum20() {
        return _gaitoum20;
    }

    /**
     * ŠY“–Œ‚Ì20“ú‚ğİ’è‚·‚é
     *
     * @param gaitoum20 ŠY“–Œ‚Ì20“ú
     */
    public void setGaitoum20(String gaitoum20) {
        this._gaitoum20 = gaitoum20;
    }

    /**
     * ŠY“–Œ‚Ì21“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì21“ú
     */
    public String getGaitoum21() {
        return _gaitoum21;
    }

    /**
     * ŠY“–Œ‚Ì21“ú‚ğİ’è‚·‚é
     *
     * @param gaitoum21 ŠY“–Œ‚Ì21“ú
     */
    public void setGaitoum21(String gaitoum21) {
        this._gaitoum21 = gaitoum21;
    }

    /**
     * ŠY“–Œ‚Ì22“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì22“ú
     */
    public String getGaitoum22() {
        return _gaitoum22;
    }

    /**
     * ŠY“–Œ‚Ì22“ú‚ğİ’è‚·‚é
     *
     * @param gaitoum22 ŠY“–Œ‚Ì22“ú
     */
    public void setGaitoum22(String gaitoum22) {
        this._gaitoum22 = gaitoum22;
    }

    /**
     * ŠY“–Œ‚Ì23“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì23“ú
     */
    public String getGaitoum23() {
        return _gaitoum23;
    }

    /**
     * ŠY“–Œ‚Ì23“ú‚ğİ’è‚·‚é
     *
     * @param gaitoum23 ŠY“–Œ‚Ì23“ú
     */
    public void setGaitoum23(String gaitoum23) {
        this._gaitoum23 = gaitoum23;
    }

    /**
     * ŠY“–Œ‚Ì24“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì24“ú
     */
    public String getGaitoum24() {
        return _gaitoum24;
    }

    /**
     * ŠY“–Œ‚Ì24“ú‚ğİ’è‚·‚é
     *
     * @param gaitoum24 ŠY“–Œ‚Ì24“ú
     */
    public void setGaitoum24(String gaitoum24) {
        this._gaitoum24 = gaitoum24;
    }

    /**
     * ŠY“–Œ‚Ì25“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì25“ú
     */
    public String getGaitoum25() {
        return _gaitoum25;
    }

    /**
     * ŠY“–Œ‚Ì25“ú‚ğİ’è‚·‚é
     *
     * @param gaitoum25 ŠY“–Œ‚Ì25“ú
     */
    public void setGaitoum25(String gaitoum25) {
        this._gaitoum25 = gaitoum25;
    }

    /**
     * ŠY“–Œ‚Ì26“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì26“ú
     */
    public String getGaitoum26() {
        return _gaitoum26;
    }

    /**
     * ŠY“–Œ‚Ì26“ú‚ğİ’è‚·‚é
     *
     * @param gaitoum26 ŠY“–Œ‚Ì26“ú
     */
    public void setGaitoum26(String gaitoum26) {
        this._gaitoum26 = gaitoum26;
    }

    /**
     * ŠY“–Œ‚Ì27“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì27“ú
     */
    public String getGaitoum27() {
        return _gaitoum27;
    }

    /**
     * ŠY“–Œ‚Ì27“ú‚ğİ’è‚·‚é
     *
     * @param gaitoum27 ŠY“–Œ‚Ì27“ú
     */
    public void setGaitoum27(String gaitoum27) {
        this._gaitoum27 = gaitoum27;
    }

    /**
     * ŠY“–Œ‚Ì28“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì28“ú
     */
    public String getGaitoum28() {
        return _gaitoum28;
    }

    /**
     * ŠY“–Œ‚Ì28“ú‚ğİ’è‚·‚é
     *
     * @param gaitoum28 ŠY“–Œ‚Ì28“ú
     */
    public void setGaitoum28(String gaitoum28) {
        this._gaitoum28 = gaitoum28;
    }

    /**
     * ŠY“–Œ‚Ì29“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì29“ú
     */
    public String getGaitoum29() {
        return _gaitoum29;
    }

    /**
     * ŠY“–Œ‚Ì29“ú‚ğİ’è‚·‚é
     *
     * @param gaitoum29 ŠY“–Œ‚Ì29“ú
     */
    public void setGaitoum29(String gaitoum29) {
        this._gaitoum29 = gaitoum29;
    }

    /**
     * ŠY“–Œ‚Ì30“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì30“ú
     */
    public String getGaitoum30() {
        return _gaitoum30;
    }

    /**
     * ŠY“–Œ‚Ì30“ú‚ğİ’è‚·‚é
     *
     * @param gaitoum30 ŠY“–Œ‚Ì30“ú
     */
    public void setGaitoum30(String gaitoum30) {
        this._gaitoum30 = gaitoum30;
    }

    /**
     * ŠY“–Œ‚Ì31“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì31“ú
     */
    public String getGaitoum31() {
        return _gaitoum31;
    }

    /**
     * ŠY“–Œ‚Ì31“ú‚ğİ’è‚·‚é
     *
     * @param gaitoum31 ŠY“–Œ‚Ì31“ú
     */
    public void setGaitoum31(String gaitoum31) {
        this._gaitoum31 = gaitoum31;
    }

    /**
     * ƒf[ƒ^XV“ú‚ğæ“¾‚·‚é
     *
     * @return ƒf[ƒ^XV“ú
     */
    @XmlElement(required = true, nillable = true)
    public Date getUpddate() {
        return _upddate;
    }

    /**
     * ƒf[ƒ^XV“ú‚ğİ’è‚·‚é
     *
     * @param upddate ƒf[ƒ^XV“ú
     */
    public void setUpddate(Date upddate) {
        this._upddate = upddate;
    }

    /**
     * ƒf[ƒ^XVÒ‚ğæ“¾‚·‚é
     *
     * @return ƒf[ƒ^XVÒ
     */
    public String getUpdnm() {
        return _updnm;
    }

    /**
     * ƒf[ƒ^XVÒ‚ğİ’è‚·‚é
     *
     * @param updnm ƒf[ƒ^XVÒ
     */
    public void setUpdnm(String updnm) {
        this._updnm = updnm;
    }

    /**
     * XVƒvƒƒOƒ‰ƒ€‚ğæ“¾‚·‚é
     *
     * @return XVƒvƒƒOƒ‰ƒ€
     */
    public String getUpdapl() {
        return _updapl;
    }

    /**
     * XVƒvƒƒOƒ‰ƒ€‚ğİ’è‚·‚é
     *
     * @param updapl XVƒvƒƒOƒ‰ƒ€
     */
    public void setUpdapl(String updapl) {
        this._updapl = updapl;
    }

    /**
     * XV’S“–ÒID‚ğæ“¾‚·‚é
     *
     * @return XV’S“–ÒID
     */
    public String getUpdid() {
        return _updid;
    }

    /**
     * XV’S“–ÒID‚ğİ’è‚·‚é
     *
     * @param updid XV’S“–ÒID
     */
    public void setUpdid(String updid) {
        this._updid = updid;
    }

}
