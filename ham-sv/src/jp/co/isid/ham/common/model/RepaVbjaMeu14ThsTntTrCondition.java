package jp.co.isid.ham.common.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * æˆøæ’S“–iæjŒŸõğŒ
 * </P>
 * <P>
 * <B>C³—š—ğ</B><BR>
 * EV‹Kì¬(2012/11/29 VHAMƒ`[ƒ€)<BR>
 * </P>
 * @author VHAMƒ`[ƒ€
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class RepaVbjaMeu14ThsTntTrCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** æˆøæŠé‹ÆƒR[ƒh */
    private String _thskgycd = null;

    /** ‚r‚d‚p‚m‚n */
    private String _seqno = null;

    /** æ’S“–‚r‚d‚p‚m‚n */
    private String _trtntseqno = null;

    /** —LŒøI—¹”NŒ“ú */
    private String _endymd = null;

    /** —LŒøŠJn”NŒ“ú */
    private String _startymd = null;

    /** \¿ÒƒR[ƒh */
    private String _snstnt = null;

    /** ‘gDƒR[ƒh */
    private String _sikcd = null;

    /** Lå‹æ•ª */
    private String _clntkbn = null;

    /** “¾ˆÓæ‹æ•ª */
    private String _tkkbn = null;

    /** ¿‹æ‹æ•ª */
    private String _skyuskbn = null;

    /** “ü‹àæ‹æ•ª */
    private String _nkinskbn = null;

    /** Œ©“¾ˆÓæ‹æ•ª */
    private String _mkmtkskbn = null;

    /** ‰c‹Æ”ï“¾ˆÓæ‹æ•ª */
    private String _eghishrskbn = null;

    /** \¿‚m‚n */
    private String _sinseino = null;

    /** ‰c‹ÆŠƒR[ƒh */
    private String _egsyocd = null;

    /** LåŠé‹ÆƒR[ƒh */
    private String _clntkgycd = null;

    /** Lå‚r‚d‚p‚m‚n */
    private String _clntseqno = null;

    /** ‹ŒæˆøæƒR[ƒh */
    private String _kyutrcd = null;

    /** æ’S“–—\”õ */
    private String _trtntyobi = null;

    /**
     * ƒfƒtƒHƒ‹ƒgƒRƒ“ƒXƒgƒ‰ƒNƒ^
     */
    public RepaVbjaMeu14ThsTntTrCondition() {
    }

    /**
     * æˆøæŠé‹ÆƒR[ƒh‚ğæ“¾‚·‚é
     *
     * @return æˆøæŠé‹ÆƒR[ƒh
     */
    public String getThskgycd() {
        return _thskgycd;
    }

    /**
     * æˆøæŠé‹ÆƒR[ƒh‚ğİ’è‚·‚é
     *
     * @param thskgycd æˆøæŠé‹ÆƒR[ƒh
     */
    public void setThskgycd(String thskgycd) {
        this._thskgycd = thskgycd;
    }

    /**
     * ‚r‚d‚p‚m‚n‚ğæ“¾‚·‚é
     *
     * @return ‚r‚d‚p‚m‚n
     */
    public String getSeqno() {
        return _seqno;
    }

    /**
     * ‚r‚d‚p‚m‚n‚ğİ’è‚·‚é
     *
     * @param seqno ‚r‚d‚p‚m‚n
     */
    public void setSeqno(String seqno) {
        this._seqno = seqno;
    }

    /**
     * æ’S“–‚r‚d‚p‚m‚n‚ğæ“¾‚·‚é
     *
     * @return æ’S“–‚r‚d‚p‚m‚n
     */
    public String getTrtntseqno() {
        return _trtntseqno;
    }

    /**
     * æ’S“–‚r‚d‚p‚m‚n‚ğİ’è‚·‚é
     *
     * @param trtntseqno æ’S“–‚r‚d‚p‚m‚n
     */
    public void setTrtntseqno(String trtntseqno) {
        this._trtntseqno = trtntseqno;
    }

    /**
     * —LŒøI—¹”NŒ“ú‚ğæ“¾‚·‚é
     *
     * @return —LŒøI—¹”NŒ“ú
     */
    public String getEndymd() {
        return _endymd;
    }

    /**
     * —LŒøI—¹”NŒ“ú‚ğİ’è‚·‚é
     *
     * @param endymd —LŒøI—¹”NŒ“ú
     */
    public void setEndymd(String endymd) {
        this._endymd = endymd;
    }

    /**
     * —LŒøŠJn”NŒ“ú‚ğæ“¾‚·‚é
     *
     * @return —LŒøŠJn”NŒ“ú
     */
    public String getStartymd() {
        return _startymd;
    }

    /**
     * —LŒøŠJn”NŒ“ú‚ğİ’è‚·‚é
     *
     * @param startymd —LŒøŠJn”NŒ“ú
     */
    public void setStartymd(String startymd) {
        this._startymd = startymd;
    }

    /**
     * \¿ÒƒR[ƒh‚ğæ“¾‚·‚é
     *
     * @return \¿ÒƒR[ƒh
     */
    public String getSnstnt() {
        return _snstnt;
    }

    /**
     * \¿ÒƒR[ƒh‚ğİ’è‚·‚é
     *
     * @param snstnt \¿ÒƒR[ƒh
     */
    public void setSnstnt(String snstnt) {
        this._snstnt = snstnt;
    }

    /**
     * ‘gDƒR[ƒh‚ğæ“¾‚·‚é
     *
     * @return ‘gDƒR[ƒh
     */
    public String getSikcd() {
        return _sikcd;
    }

    /**
     * ‘gDƒR[ƒh‚ğİ’è‚·‚é
     *
     * @param sikcd ‘gDƒR[ƒh
     */
    public void setSikcd(String sikcd) {
        this._sikcd = sikcd;
    }

    /**
     * Lå‹æ•ª‚ğæ“¾‚·‚é
     *
     * @return Lå‹æ•ª
     */
    public String getClntkbn() {
        return _clntkbn;
    }

    /**
     * Lå‹æ•ª‚ğİ’è‚·‚é
     *
     * @param clntkbn Lå‹æ•ª
     */
    public void setClntkbn(String clntkbn) {
        this._clntkbn = clntkbn;
    }

    /**
     * “¾ˆÓæ‹æ•ª‚ğæ“¾‚·‚é
     *
     * @return “¾ˆÓæ‹æ•ª
     */
    public String getTkkbn() {
        return _tkkbn;
    }

    /**
     * “¾ˆÓæ‹æ•ª‚ğİ’è‚·‚é
     *
     * @param tkkbn “¾ˆÓæ‹æ•ª
     */
    public void setTkkbn(String tkkbn) {
        this._tkkbn = tkkbn;
    }

    /**
     * ¿‹æ‹æ•ª‚ğæ“¾‚·‚é
     *
     * @return ¿‹æ‹æ•ª
     */
    public String getSkyuskbn() {
        return _skyuskbn;
    }

    /**
     * ¿‹æ‹æ•ª‚ğİ’è‚·‚é
     *
     * @param skyuskbn ¿‹æ‹æ•ª
     */
    public void setSkyuskbn(String skyuskbn) {
        this._skyuskbn = skyuskbn;
    }

    /**
     * “ü‹àæ‹æ•ª‚ğæ“¾‚·‚é
     *
     * @return “ü‹àæ‹æ•ª
     */
    public String getNkinskbn() {
        return _nkinskbn;
    }

    /**
     * “ü‹àæ‹æ•ª‚ğİ’è‚·‚é
     *
     * @param nkinskbn “ü‹àæ‹æ•ª
     */
    public void setNkinskbn(String nkinskbn) {
        this._nkinskbn = nkinskbn;
    }

    /**
     * Œ©“¾ˆÓæ‹æ•ª‚ğæ“¾‚·‚é
     *
     * @return Œ©“¾ˆÓæ‹æ•ª
     */
    public String getMkmtkskbn() {
        return _mkmtkskbn;
    }

    /**
     * Œ©“¾ˆÓæ‹æ•ª‚ğİ’è‚·‚é
     *
     * @param mkmtkskbn Œ©“¾ˆÓæ‹æ•ª
     */
    public void setMkmtkskbn(String mkmtkskbn) {
        this._mkmtkskbn = mkmtkskbn;
    }

    /**
     * ‰c‹Æ”ï“¾ˆÓæ‹æ•ª‚ğæ“¾‚·‚é
     *
     * @return ‰c‹Æ”ï“¾ˆÓæ‹æ•ª
     */
    public String getEghishrskbn() {
        return _eghishrskbn;
    }

    /**
     * ‰c‹Æ”ï“¾ˆÓæ‹æ•ª‚ğİ’è‚·‚é
     *
     * @param eghishrskbn ‰c‹Æ”ï“¾ˆÓæ‹æ•ª
     */
    public void setEghishrskbn(String eghishrskbn) {
        this._eghishrskbn = eghishrskbn;
    }

    /**
     * \¿‚m‚n‚ğæ“¾‚·‚é
     *
     * @return \¿‚m‚n
     */
    public String getSinseino() {
        return _sinseino;
    }

    /**
     * \¿‚m‚n‚ğİ’è‚·‚é
     *
     * @param sinseino \¿‚m‚n
     */
    public void setSinseino(String sinseino) {
        this._sinseino = sinseino;
    }

    /**
     * ‰c‹ÆŠƒR[ƒh‚ğæ“¾‚·‚é
     *
     * @return ‰c‹ÆŠƒR[ƒh
     */
    public String getEgsyocd() {
        return _egsyocd;
    }

    /**
     * ‰c‹ÆŠƒR[ƒh‚ğİ’è‚·‚é
     *
     * @param egsyocd ‰c‹ÆŠƒR[ƒh
     */
    public void setEgsyocd(String egsyocd) {
        this._egsyocd = egsyocd;
    }

    /**
     * LåŠé‹ÆƒR[ƒh‚ğæ“¾‚·‚é
     *
     * @return LåŠé‹ÆƒR[ƒh
     */
    public String getClntkgycd() {
        return _clntkgycd;
    }

    /**
     * LåŠé‹ÆƒR[ƒh‚ğİ’è‚·‚é
     *
     * @param clntkgycd LåŠé‹ÆƒR[ƒh
     */
    public void setClntkgycd(String clntkgycd) {
        this._clntkgycd = clntkgycd;
    }

    /**
     * Lå‚r‚d‚p‚m‚n‚ğæ“¾‚·‚é
     *
     * @return Lå‚r‚d‚p‚m‚n
     */
    public String getClntseqno() {
        return _clntseqno;
    }

    /**
     * Lå‚r‚d‚p‚m‚n‚ğİ’è‚·‚é
     *
     * @param clntseqno Lå‚r‚d‚p‚m‚n
     */
    public void setClntseqno(String clntseqno) {
        this._clntseqno = clntseqno;
    }

    /**
     * ‹ŒæˆøæƒR[ƒh‚ğæ“¾‚·‚é
     *
     * @return ‹ŒæˆøæƒR[ƒh
     */
    public String getKyutrcd() {
        return _kyutrcd;
    }

    /**
     * ‹ŒæˆøæƒR[ƒh‚ğİ’è‚·‚é
     *
     * @param kyutrcd ‹ŒæˆøæƒR[ƒh
     */
    public void setKyutrcd(String kyutrcd) {
        this._kyutrcd = kyutrcd;
    }

    /**
     * æ’S“–—\”õ‚ğæ“¾‚·‚é
     *
     * @return æ’S“–—\”õ
     */
    public String getTrtntyobi() {
        return _trtntyobi;
    }

    /**
     * æ’S“–—\”õ‚ğİ’è‚·‚é
     *
     * @param trtntyobi æ’S“–—\”õ
     */
    public void setTrtntyobi(String trtntyobi) {
        this._trtntyobi = trtntyobi;
    }

}
