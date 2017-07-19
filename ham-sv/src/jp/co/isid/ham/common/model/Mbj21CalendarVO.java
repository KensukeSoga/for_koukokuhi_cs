package jp.co.isid.ham.common.model;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj21Calendar;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * ƒJƒŒƒ“ƒ_[ƒ}ƒXƒ^VO
 * </P>
 * <P>
 * <B>C³—š—ğ</B><BR>
 * EV‹Kì¬(2012/11/29 VHAMƒ`[ƒ€)<BR>
 * </P>
 * @author VHAMƒ`[ƒ€
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj21CalendarVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * ƒfƒtƒHƒ‹ƒgƒRƒ“ƒXƒgƒ‰ƒNƒ^
     */
    public Mbj21CalendarVO() {
    }

    /**
     * V‹KƒCƒ“ƒXƒ^ƒ“ƒX‚ğ¶¬‚·‚é
     *
     * @return V‹KƒCƒ“ƒXƒ^ƒ“ƒX
     */
    public Object newInstance() {
        return new Mbj21CalendarVO();
    }

    /**
     * ƒf[ƒ^‹æ•ª‚ğæ“¾‚·‚é
     *
     * @return ƒf[ƒ^‹æ•ª
     */
    public String getDATAKBN() {
        return (String) get(Mbj21Calendar.DATAKBN);
    }

    /**
     * ƒf[ƒ^‹æ•ª‚ğİ’è‚·‚é
     *
     * @param val ƒf[ƒ^‹æ•ª
     */
    public void setDATAKBN(String val) {
        set(Mbj21Calendar.DATAKBN, val);
    }

    /**
     * ƒJƒŒƒ“ƒ_”NŒ‚ğæ“¾‚·‚é
     *
     * @return ƒJƒŒƒ“ƒ_”NŒ
     */
    public String getCALENDARYM() {
        return (String) get(Mbj21Calendar.CALENDARYM);
    }

    /**
     * ƒJƒŒƒ“ƒ_”NŒ‚ğİ’è‚·‚é
     *
     * @param val ƒJƒŒƒ“ƒ_”NŒ
     */
    public void setCALENDARYM(String val) {
        set(Mbj21Calendar.CALENDARYM, val);
    }

    /**
     * ŠY“–Œ‚Ì1“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì1“ú
     */
    public String getGAITOUM1() {
        return (String) get(Mbj21Calendar.GAITOUM1);
    }

    /**
     * ŠY“–Œ‚Ì1“ú‚ğİ’è‚·‚é
     *
     * @param val ŠY“–Œ‚Ì1“ú
     */
    public void setGAITOUM1(String val) {
        set(Mbj21Calendar.GAITOUM1, val);
    }

    /**
     * ŠY“–Œ‚Ì2“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì2“ú
     */
    public String getGAITOUM2() {
        return (String) get(Mbj21Calendar.GAITOUM2);
    }

    /**
     * ŠY“–Œ‚Ì2“ú‚ğİ’è‚·‚é
     *
     * @param val ŠY“–Œ‚Ì2“ú
     */
    public void setGAITOUM2(String val) {
        set(Mbj21Calendar.GAITOUM2, val);
    }

    /**
     * ŠY“–Œ‚Ì3“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì3“ú
     */
    public String getGAITOUM3() {
        return (String) get(Mbj21Calendar.GAITOUM3);
    }

    /**
     * ŠY“–Œ‚Ì3“ú‚ğİ’è‚·‚é
     *
     * @param val ŠY“–Œ‚Ì3“ú
     */
    public void setGAITOUM3(String val) {
        set(Mbj21Calendar.GAITOUM3, val);
    }

    /**
     * ŠY“–Œ‚Ì4“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì4“ú
     */
    public String getGAITOUM4() {
        return (String) get(Mbj21Calendar.GAITOUM4);
    }

    /**
     * ŠY“–Œ‚Ì4“ú‚ğİ’è‚·‚é
     *
     * @param val ŠY“–Œ‚Ì4“ú
     */
    public void setGAITOUM4(String val) {
        set(Mbj21Calendar.GAITOUM4, val);
    }

    /**
     * ŠY“–Œ‚Ì5“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì5“ú
     */
    public String getGAITOUM5() {
        return (String) get(Mbj21Calendar.GAITOUM5);
    }

    /**
     * ŠY“–Œ‚Ì5“ú‚ğİ’è‚·‚é
     *
     * @param val ŠY“–Œ‚Ì5“ú
     */
    public void setGAITOUM5(String val) {
        set(Mbj21Calendar.GAITOUM5, val);
    }

    /**
     * ŠY“–Œ‚Ì6“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì6“ú
     */
    public String getGAITOUM6() {
        return (String) get(Mbj21Calendar.GAITOUM6);
    }

    /**
     * ŠY“–Œ‚Ì6“ú‚ğİ’è‚·‚é
     *
     * @param val ŠY“–Œ‚Ì6“ú
     */
    public void setGAITOUM6(String val) {
        set(Mbj21Calendar.GAITOUM6, val);
    }

    /**
     * ŠY“–Œ‚Ì7“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì7“ú
     */
    public String getGAITOUM7() {
        return (String) get(Mbj21Calendar.GAITOUM7);
    }

    /**
     * ŠY“–Œ‚Ì7“ú‚ğİ’è‚·‚é
     *
     * @param val ŠY“–Œ‚Ì7“ú
     */
    public void setGAITOUM7(String val) {
        set(Mbj21Calendar.GAITOUM7, val);
    }

    /**
     * ŠY“–Œ‚Ì8“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì8“ú
     */
    public String getGAITOUM8() {
        return (String) get(Mbj21Calendar.GAITOUM8);
    }

    /**
     * ŠY“–Œ‚Ì8“ú‚ğİ’è‚·‚é
     *
     * @param val ŠY“–Œ‚Ì8“ú
     */
    public void setGAITOUM8(String val) {
        set(Mbj21Calendar.GAITOUM8, val);
    }

    /**
     * ŠY“–Œ‚Ì9“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì9“ú
     */
    public String getGAITOUM9() {
        return (String) get(Mbj21Calendar.GAITOUM9);
    }

    /**
     * ŠY“–Œ‚Ì9“ú‚ğİ’è‚·‚é
     *
     * @param val ŠY“–Œ‚Ì9“ú
     */
    public void setGAITOUM9(String val) {
        set(Mbj21Calendar.GAITOUM9, val);
    }

    /**
     * ŠY“–Œ‚Ì10“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì10“ú
     */
    public String getGAITOUM10() {
        return (String) get(Mbj21Calendar.GAITOUM10);
    }

    /**
     * ŠY“–Œ‚Ì10“ú‚ğİ’è‚·‚é
     *
     * @param val ŠY“–Œ‚Ì10“ú
     */
    public void setGAITOUM10(String val) {
        set(Mbj21Calendar.GAITOUM10, val);
    }

    /**
     * ŠY“–Œ‚Ì11“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì11“ú
     */
    public String getGAITOUM11() {
        return (String) get(Mbj21Calendar.GAITOUM11);
    }

    /**
     * ŠY“–Œ‚Ì11“ú‚ğİ’è‚·‚é
     *
     * @param val ŠY“–Œ‚Ì11“ú
     */
    public void setGAITOUM11(String val) {
        set(Mbj21Calendar.GAITOUM11, val);
    }

    /**
     * ŠY“–Œ‚Ì12“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì12“ú
     */
    public String getGAITOUM12() {
        return (String) get(Mbj21Calendar.GAITOUM12);
    }

    /**
     * ŠY“–Œ‚Ì12“ú‚ğİ’è‚·‚é
     *
     * @param val ŠY“–Œ‚Ì12“ú
     */
    public void setGAITOUM12(String val) {
        set(Mbj21Calendar.GAITOUM12, val);
    }

    /**
     * ŠY“–Œ‚Ì13“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì13“ú
     */
    public String getGAITOUM13() {
        return (String) get(Mbj21Calendar.GAITOUM13);
    }

    /**
     * ŠY“–Œ‚Ì13“ú‚ğİ’è‚·‚é
     *
     * @param val ŠY“–Œ‚Ì13“ú
     */
    public void setGAITOUM13(String val) {
        set(Mbj21Calendar.GAITOUM13, val);
    }

    /**
     * ŠY“–Œ‚Ì14“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì14“ú
     */
    public String getGAITOUM14() {
        return (String) get(Mbj21Calendar.GAITOUM14);
    }

    /**
     * ŠY“–Œ‚Ì14“ú‚ğİ’è‚·‚é
     *
     * @param val ŠY“–Œ‚Ì14“ú
     */
    public void setGAITOUM14(String val) {
        set(Mbj21Calendar.GAITOUM14, val);
    }

    /**
     * ŠY“–Œ‚Ì15“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì15“ú
     */
    public String getGAITOUM15() {
        return (String) get(Mbj21Calendar.GAITOUM15);
    }

    /**
     * ŠY“–Œ‚Ì15“ú‚ğİ’è‚·‚é
     *
     * @param val ŠY“–Œ‚Ì15“ú
     */
    public void setGAITOUM15(String val) {
        set(Mbj21Calendar.GAITOUM15, val);
    }

    /**
     * ŠY“–Œ‚Ì16“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì16“ú
     */
    public String getGAITOUM16() {
        return (String) get(Mbj21Calendar.GAITOUM16);
    }

    /**
     * ŠY“–Œ‚Ì16“ú‚ğİ’è‚·‚é
     *
     * @param val ŠY“–Œ‚Ì16“ú
     */
    public void setGAITOUM16(String val) {
        set(Mbj21Calendar.GAITOUM16, val);
    }

    /**
     * ŠY“–Œ‚Ì17“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì17“ú
     */
    public String getGAITOUM17() {
        return (String) get(Mbj21Calendar.GAITOUM17);
    }

    /**
     * ŠY“–Œ‚Ì17“ú‚ğİ’è‚·‚é
     *
     * @param val ŠY“–Œ‚Ì17“ú
     */
    public void setGAITOUM17(String val) {
        set(Mbj21Calendar.GAITOUM17, val);
    }

    /**
     * ŠY“–Œ‚Ì18“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì18“ú
     */
    public String getGAITOUM18() {
        return (String) get(Mbj21Calendar.GAITOUM18);
    }

    /**
     * ŠY“–Œ‚Ì18“ú‚ğİ’è‚·‚é
     *
     * @param val ŠY“–Œ‚Ì18“ú
     */
    public void setGAITOUM18(String val) {
        set(Mbj21Calendar.GAITOUM18, val);
    }

    /**
     * ŠY“–Œ‚Ì19“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì19“ú
     */
    public String getGAITOUM19() {
        return (String) get(Mbj21Calendar.GAITOUM19);
    }

    /**
     * ŠY“–Œ‚Ì19“ú‚ğİ’è‚·‚é
     *
     * @param val ŠY“–Œ‚Ì19“ú
     */
    public void setGAITOUM19(String val) {
        set(Mbj21Calendar.GAITOUM19, val);
    }

    /**
     * ŠY“–Œ‚Ì20“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì20“ú
     */
    public String getGAITOUM20() {
        return (String) get(Mbj21Calendar.GAITOUM20);
    }

    /**
     * ŠY“–Œ‚Ì20“ú‚ğİ’è‚·‚é
     *
     * @param val ŠY“–Œ‚Ì20“ú
     */
    public void setGAITOUM20(String val) {
        set(Mbj21Calendar.GAITOUM20, val);
    }

    /**
     * ŠY“–Œ‚Ì21“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì21“ú
     */
    public String getGAITOUM21() {
        return (String) get(Mbj21Calendar.GAITOUM21);
    }

    /**
     * ŠY“–Œ‚Ì21“ú‚ğİ’è‚·‚é
     *
     * @param val ŠY“–Œ‚Ì21“ú
     */
    public void setGAITOUM21(String val) {
        set(Mbj21Calendar.GAITOUM21, val);
    }

    /**
     * ŠY“–Œ‚Ì22“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì22“ú
     */
    public String getGAITOUM22() {
        return (String) get(Mbj21Calendar.GAITOUM22);
    }

    /**
     * ŠY“–Œ‚Ì22“ú‚ğİ’è‚·‚é
     *
     * @param val ŠY“–Œ‚Ì22“ú
     */
    public void setGAITOUM22(String val) {
        set(Mbj21Calendar.GAITOUM22, val);
    }

    /**
     * ŠY“–Œ‚Ì23“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì23“ú
     */
    public String getGAITOUM23() {
        return (String) get(Mbj21Calendar.GAITOUM23);
    }

    /**
     * ŠY“–Œ‚Ì23“ú‚ğİ’è‚·‚é
     *
     * @param val ŠY“–Œ‚Ì23“ú
     */
    public void setGAITOUM23(String val) {
        set(Mbj21Calendar.GAITOUM23, val);
    }

    /**
     * ŠY“–Œ‚Ì24“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì24“ú
     */
    public String getGAITOUM24() {
        return (String) get(Mbj21Calendar.GAITOUM24);
    }

    /**
     * ŠY“–Œ‚Ì24“ú‚ğİ’è‚·‚é
     *
     * @param val ŠY“–Œ‚Ì24“ú
     */
    public void setGAITOUM24(String val) {
        set(Mbj21Calendar.GAITOUM24, val);
    }

    /**
     * ŠY“–Œ‚Ì25“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì25“ú
     */
    public String getGAITOUM25() {
        return (String) get(Mbj21Calendar.GAITOUM25);
    }

    /**
     * ŠY“–Œ‚Ì25“ú‚ğİ’è‚·‚é
     *
     * @param val ŠY“–Œ‚Ì25“ú
     */
    public void setGAITOUM25(String val) {
        set(Mbj21Calendar.GAITOUM25, val);
    }

    /**
     * ŠY“–Œ‚Ì26“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì26“ú
     */
    public String getGAITOUM26() {
        return (String) get(Mbj21Calendar.GAITOUM26);
    }

    /**
     * ŠY“–Œ‚Ì26“ú‚ğİ’è‚·‚é
     *
     * @param val ŠY“–Œ‚Ì26“ú
     */
    public void setGAITOUM26(String val) {
        set(Mbj21Calendar.GAITOUM26, val);
    }

    /**
     * ŠY“–Œ‚Ì27“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì27“ú
     */
    public String getGAITOUM27() {
        return (String) get(Mbj21Calendar.GAITOUM27);
    }

    /**
     * ŠY“–Œ‚Ì27“ú‚ğİ’è‚·‚é
     *
     * @param val ŠY“–Œ‚Ì27“ú
     */
    public void setGAITOUM27(String val) {
        set(Mbj21Calendar.GAITOUM27, val);
    }

    /**
     * ŠY“–Œ‚Ì28“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì28“ú
     */
    public String getGAITOUM28() {
        return (String) get(Mbj21Calendar.GAITOUM28);
    }

    /**
     * ŠY“–Œ‚Ì28“ú‚ğİ’è‚·‚é
     *
     * @param val ŠY“–Œ‚Ì28“ú
     */
    public void setGAITOUM28(String val) {
        set(Mbj21Calendar.GAITOUM28, val);
    }

    /**
     * ŠY“–Œ‚Ì29“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì29“ú
     */
    public String getGAITOUM29() {
        return (String) get(Mbj21Calendar.GAITOUM29);
    }

    /**
     * ŠY“–Œ‚Ì29“ú‚ğİ’è‚·‚é
     *
     * @param val ŠY“–Œ‚Ì29“ú
     */
    public void setGAITOUM29(String val) {
        set(Mbj21Calendar.GAITOUM29, val);
    }

    /**
     * ŠY“–Œ‚Ì30“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì30“ú
     */
    public String getGAITOUM30() {
        return (String) get(Mbj21Calendar.GAITOUM30);
    }

    /**
     * ŠY“–Œ‚Ì30“ú‚ğİ’è‚·‚é
     *
     * @param val ŠY“–Œ‚Ì30“ú
     */
    public void setGAITOUM30(String val) {
        set(Mbj21Calendar.GAITOUM30, val);
    }

    /**
     * ŠY“–Œ‚Ì31“ú‚ğæ“¾‚·‚é
     *
     * @return ŠY“–Œ‚Ì31“ú
     */
    public String getGAITOUM31() {
        return (String) get(Mbj21Calendar.GAITOUM31);
    }

    /**
     * ŠY“–Œ‚Ì31“ú‚ğİ’è‚·‚é
     *
     * @param val ŠY“–Œ‚Ì31“ú
     */
    public void setGAITOUM31(String val) {
        set(Mbj21Calendar.GAITOUM31, val);
    }

    /**
     * ƒf[ƒ^XV“ú‚ğæ“¾‚·‚é
     *
     * @return ƒf[ƒ^XV“ú
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Mbj21Calendar.UPDDATE);
    }

    /**
     * ƒf[ƒ^XV“ú‚ğİ’è‚·‚é
     *
     * @param val ƒf[ƒ^XV“ú
     */
    public void setUPDDATE(Date val) {
        set(Mbj21Calendar.UPDDATE, val);
    }

    /**
     * ƒf[ƒ^XVÒ‚ğæ“¾‚·‚é
     *
     * @return ƒf[ƒ^XVÒ
     */
    public String getUPDNM() {
        return (String) get(Mbj21Calendar.UPDNM);
    }

    /**
     * ƒf[ƒ^XVÒ‚ğİ’è‚·‚é
     *
     * @param val ƒf[ƒ^XVÒ
     */
    public void setUPDNM(String val) {
        set(Mbj21Calendar.UPDNM, val);
    }

    /**
     * XVƒvƒƒOƒ‰ƒ€‚ğæ“¾‚·‚é
     *
     * @return XVƒvƒƒOƒ‰ƒ€
     */
    public String getUPDAPL() {
        return (String) get(Mbj21Calendar.UPDAPL);
    }

    /**
     * XVƒvƒƒOƒ‰ƒ€‚ğİ’è‚·‚é
     *
     * @param val XVƒvƒƒOƒ‰ƒ€
     */
    public void setUPDAPL(String val) {
        set(Mbj21Calendar.UPDAPL, val);
    }

    /**
     * XV’S“–ÒID‚ğæ“¾‚·‚é
     *
     * @return XV’S“–ÒID
     */
    public String getUPDID() {
        return (String) get(Mbj21Calendar.UPDID);
    }

    /**
     * XV’S“–ÒID‚ğİ’è‚·‚é
     *
     * @param val XV’S“–ÒID
     */
    public void setUPDID(String val) {
        set(Mbj21Calendar.UPDID, val);
    }

}
