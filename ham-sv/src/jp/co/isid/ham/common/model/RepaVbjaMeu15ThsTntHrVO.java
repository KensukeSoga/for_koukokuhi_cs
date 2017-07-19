package jp.co.isid.ham.common.model;


import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu15ThsTntHr;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * æˆøæ’S“–i•¥jVO
 * </P>
 * <P>
 * <B>C³—š—ğ</B><BR>
 * EV‹Kì¬(2012/11/29 VHAMƒ`[ƒ€)<BR>
 * </P>
 * @author VHAMƒ`[ƒ€
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class RepaVbjaMeu15ThsTntHrVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * ƒfƒtƒHƒ‹ƒgƒRƒ“ƒXƒgƒ‰ƒNƒ^
     */
    public RepaVbjaMeu15ThsTntHrVO() {
    }

    /**
     * V‹KƒCƒ“ƒXƒ^ƒ“ƒX‚ğ¶¬‚·‚é
     *
     * @return V‹KƒCƒ“ƒXƒ^ƒ“ƒX
     */
    public Object newInstance() {
        return new RepaVbjaMeu15ThsTntHrVO();
    }

    /**
     * æˆøæŠé‹ÆƒR[ƒh‚ğæ“¾‚·‚é
     *
     * @return æˆøæŠé‹ÆƒR[ƒh
     */
    public String getTHSKGYCD() {
        return (String) get(RepaVbjaMeu15ThsTntHr.THSKGYCD);
    }

    /**
     * æˆøæŠé‹ÆƒR[ƒh‚ğİ’è‚·‚é
     *
     * @param val æˆøæŠé‹ÆƒR[ƒh
     */
    public void setTHSKGYCD(String val) {
        set(RepaVbjaMeu15ThsTntHr.THSKGYCD, val);
    }

    /**
     * ‚r‚d‚p‚m‚n‚ğæ“¾‚·‚é
     *
     * @return ‚r‚d‚p‚m‚n
     */
    public String getSEQNO() {
        return (String) get(RepaVbjaMeu15ThsTntHr.SEQNO);
    }

    /**
     * ‚r‚d‚p‚m‚n‚ğİ’è‚·‚é
     *
     * @param val ‚r‚d‚p‚m‚n
     */
    public void setSEQNO(String val) {
        set(RepaVbjaMeu15ThsTntHr.SEQNO, val);
    }

    /**
     * •¥’S“–‚r‚d‚p‚m‚n‚ğæ“¾‚·‚é
     *
     * @return •¥’S“–‚r‚d‚p‚m‚n
     */
    public String getHRTNTSEQNO() {
        return (String) get(RepaVbjaMeu15ThsTntHr.HRTNTSEQNO);
    }

    /**
     * •¥’S“–‚r‚d‚p‚m‚n‚ğİ’è‚·‚é
     *
     * @param val •¥’S“–‚r‚d‚p‚m‚n
     */
    public void setHRTNTSEQNO(String val) {
        set(RepaVbjaMeu15ThsTntHr.HRTNTSEQNO, val);
    }

    /**
     * —LŒøI—¹”NŒ“ú‚ğæ“¾‚·‚é
     *
     * @return —LŒøI—¹”NŒ“ú
     */
    public String getENDYMD() {
        return (String) get(RepaVbjaMeu15ThsTntHr.ENDYMD);
    }

    /**
     * —LŒøI—¹”NŒ“ú‚ğİ’è‚·‚é
     *
     * @param val —LŒøI—¹”NŒ“ú
     */
    public void setENDYMD(String val) {
        set(RepaVbjaMeu15ThsTntHr.ENDYMD, val);
    }

    /**
     * —LŒøŠJn”NŒ“ú‚ğæ“¾‚·‚é
     *
     * @return —LŒøŠJn”NŒ“ú
     */
    public String getSTARTYMD() {
        return (String) get(RepaVbjaMeu15ThsTntHr.STARTYMD);
    }

    /**
     * —LŒøŠJn”NŒ“ú‚ğİ’è‚·‚é
     *
     * @param val —LŒøŠJn”NŒ“ú
     */
    public void setSTARTYMD(String val) {
        set(RepaVbjaMeu15ThsTntHr.STARTYMD, val);
    }

    /**
     * \¿ÒƒR[ƒh‚ğæ“¾‚·‚é
     *
     * @return \¿ÒƒR[ƒh
     */
    public String getSNSTNT() {
        return (String) get(RepaVbjaMeu15ThsTntHr.SNSTNT);
    }

    /**
     * \¿ÒƒR[ƒh‚ğİ’è‚·‚é
     *
     * @param val \¿ÒƒR[ƒh
     */
    public void setSNSTNT(String val) {
        set(RepaVbjaMeu15ThsTntHr.SNSTNT, val);
    }

    /**
     * ‘gDƒR[ƒh‚ğæ“¾‚·‚é
     *
     * @return ‘gDƒR[ƒh
     */
    public String getSIKCD() {
        return (String) get(RepaVbjaMeu15ThsTntHr.SIKCD);
    }

    /**
     * ‘gDƒR[ƒh‚ğİ’è‚·‚é
     *
     * @param val ‘gDƒR[ƒh
     */
    public void setSIKCD(String val) {
        set(RepaVbjaMeu15ThsTntHr.SIKCD, val);
    }

    /**
     * x•¥æ‹æ•ª‚ğæ“¾‚·‚é
     *
     * @return x•¥æ‹æ•ª
     */
    public String getSHRKBN() {
        return (String) get(RepaVbjaMeu15ThsTntHr.SHRKBN);
    }

    /**
     * x•¥æ‹æ•ª‚ğİ’è‚·‚é
     *
     * @param val x•¥æ‹æ•ª
     */
    public void setSHRKBN(String val) {
        set(RepaVbjaMeu15ThsTntHr.SHRKBN, val);
    }

    /**
     * Uæ‹æ•ª‚ğæ“¾‚·‚é
     *
     * @return Uæ‹æ•ª
     */
    public String getFRKSKBN() {
        return (String) get(RepaVbjaMeu15ThsTntHr.FRKSKBN);
    }

    /**
     * Uæ‹æ•ª‚ğİ’è‚·‚é
     *
     * @param val Uæ‹æ•ª
     */
    public void setFRKSKBN(String val) {
        set(RepaVbjaMeu15ThsTntHr.FRKSKBN, val);
    }

    /**
     * ‰c‹Æ”ïx•¥æ‹æ•ª‚ğæ“¾‚·‚é
     *
     * @return ‰c‹Æ”ïx•¥æ‹æ•ª
     */
    public String getEGHISHRSKBN() {
        return (String) get(RepaVbjaMeu15ThsTntHr.EGHISHRSKBN);
    }

    /**
     * ‰c‹Æ”ïx•¥æ‹æ•ª‚ğİ’è‚·‚é
     *
     * @param val ‰c‹Æ”ïx•¥æ‹æ•ª
     */
    public void setEGHISHRSKBN(String val) {
        set(RepaVbjaMeu15ThsTntHr.EGHISHRSKBN, val);
    }

    /**
     * İ’èx•¥æ‹æ•ª‚ğæ“¾‚·‚é
     *
     * @return İ’èx•¥æ‹æ•ª
     */
    public String getSTYSHRSKBN() {
        return (String) get(RepaVbjaMeu15ThsTntHr.STYSHRSKBN);
    }

    /**
     * İ’èx•¥æ‹æ•ª‚ğİ’è‚·‚é
     *
     * @param val İ’èx•¥æ‹æ•ª
     */
    public void setSTYSHRSKBN(String val) {
        set(RepaVbjaMeu15ThsTntHr.STYSHRSKBN, val);
    }

    /**
     * \¿‚m‚n‚ğæ“¾‚·‚é
     *
     * @return \¿‚m‚n
     */
    public String getSINSEINO() {
        return (String) get(RepaVbjaMeu15ThsTntHr.SINSEINO);
    }

    /**
     * \¿‚m‚n‚ğİ’è‚·‚é
     *
     * @param val \¿‚m‚n
     */
    public void setSINSEINO(String val) {
        set(RepaVbjaMeu15ThsTntHr.SINSEINO, val);
    }

    /**
     * ‰c‹ÆŠƒR[ƒh‚ğæ“¾‚·‚é
     *
     * @return ‰c‹ÆŠƒR[ƒh
     */
    public String getEGSYOCD() {
        return (String) get(RepaVbjaMeu15ThsTntHr.EGSYOCD);
    }

    /**
     * ‰c‹ÆŠƒR[ƒh‚ğİ’è‚·‚é
     *
     * @param val ‰c‹ÆŠƒR[ƒh
     */
    public void setEGSYOCD(String val) {
        set(RepaVbjaMeu15ThsTntHr.EGSYOCD, val);
    }

    /**
     * x•¥ğŒ‚o‚s‚m‚m‚n‚ğæ“¾‚·‚é
     *
     * @return x•¥ğŒ‚o‚s‚m‚m‚n
     */
    public String getSHJYOKNPTNNO() {
        return (String) get(RepaVbjaMeu15ThsTntHr.SHJYOKNPTNNO);
    }

    /**
     * x•¥ğŒ‚o‚s‚m‚m‚n‚ğİ’è‚·‚é
     *
     * @param val x•¥ğŒ‚o‚s‚m‚m‚n
     */
    public void setSHJYOKNPTNNO(String val) {
        set(RepaVbjaMeu15ThsTntHr.SHJYOKNPTNNO, val);
    }

    /**
     * ‹ŒæˆøæƒR[ƒh‚ğæ“¾‚·‚é
     *
     * @return ‹ŒæˆøæƒR[ƒh
     */
    public String getKYUTRCD() {
        return (String) get(RepaVbjaMeu15ThsTntHr.KYUTRCD);
    }

    /**
     * ‹ŒæˆøæƒR[ƒh‚ğİ’è‚·‚é
     *
     * @param val ‹ŒæˆøæƒR[ƒh
     */
    public void setKYUTRCD(String val) {
        set(RepaVbjaMeu15ThsTntHr.KYUTRCD, val);
    }

    /**
     * •¥’S“–—\”õ‚ğæ“¾‚·‚é
     *
     * @return •¥’S“–—\”õ
     */
    public String getHRTNTYOBI() {
        return (String) get(RepaVbjaMeu15ThsTntHr.HRTNTYOBI);
    }

    /**
     * •¥’S“–—\”õ‚ğİ’è‚·‚é
     *
     * @param val •¥’S“–—\”õ
     */
    public void setHRTNTYOBI(String val) {
        set(RepaVbjaMeu15ThsTntHr.HRTNTYOBI, val);
    }

}
