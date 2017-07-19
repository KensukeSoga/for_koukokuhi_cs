package jp.co.isid.ham.common.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * æˆøæ’S“–i•¥jŒŸõğŒ
 * </P>
 * <P>
 * <B>C³—š—ğ</B><BR>
 * EV‹Kì¬(2012/11/29 VHAMƒ`[ƒ€)<BR>
 * </P>
 * @author VHAMƒ`[ƒ€
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class RepaVbjaMeu15ThsTntHrCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** æˆøæŠé‹ÆƒR[ƒh */
    private String _thskgycd = null;

    /** ‚r‚d‚p‚m‚n */
    private String _seqno = null;

    /** •¥’S“–‚r‚d‚p‚m‚n */
    private String _hrtntseqno = null;

    /** —LŒøI—¹”NŒ“ú */
    private String _endymd = null;

    /** —LŒøŠJn”NŒ“ú */
    private String _startymd = null;

    /** \¿ÒƒR[ƒh */
    private String _snstnt = null;

    /** ‘gDƒR[ƒh */
    private String _sikcd = null;

    /** x•¥æ‹æ•ª */
    private String _shrkbn = null;

    /** Uæ‹æ•ª */
    private String _frkskbn = null;

    /** ‰c‹Æ”ïx•¥æ‹æ•ª */
    private String _eghishrskbn = null;

    /** İ’èx•¥æ‹æ•ª */
    private String _styshrskbn = null;

    /** \¿‚m‚n */
    private String _sinseino = null;

    /** ‰c‹ÆŠƒR[ƒh */
    private String _egsyocd = null;

    /** x•¥ğŒ‚o‚s‚m‚m‚n */
    private String _shjyoknptnno = null;

    /** ‹ŒæˆøæƒR[ƒh */
    private String _kyutrcd = null;

    /** •¥’S“–—\”õ */
    private String _hrtntyobi = null;

    /**
     * ƒfƒtƒHƒ‹ƒgƒRƒ“ƒXƒgƒ‰ƒNƒ^
     */
    public RepaVbjaMeu15ThsTntHrCondition() {
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
     * •¥’S“–‚r‚d‚p‚m‚n‚ğæ“¾‚·‚é
     *
     * @return •¥’S“–‚r‚d‚p‚m‚n
     */
    public String getHrtntseqno() {
        return _hrtntseqno;
    }

    /**
     * •¥’S“–‚r‚d‚p‚m‚n‚ğİ’è‚·‚é
     *
     * @param hrtntseqno •¥’S“–‚r‚d‚p‚m‚n
     */
    public void setHrtntseqno(String hrtntseqno) {
        this._hrtntseqno = hrtntseqno;
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
     * x•¥æ‹æ•ª‚ğæ“¾‚·‚é
     *
     * @return x•¥æ‹æ•ª
     */
    public String getShrkbn() {
        return _shrkbn;
    }

    /**
     * x•¥æ‹æ•ª‚ğİ’è‚·‚é
     *
     * @param shrkbn x•¥æ‹æ•ª
     */
    public void setShrkbn(String shrkbn) {
        this._shrkbn = shrkbn;
    }

    /**
     * Uæ‹æ•ª‚ğæ“¾‚·‚é
     *
     * @return Uæ‹æ•ª
     */
    public String getFrkskbn() {
        return _frkskbn;
    }

    /**
     * Uæ‹æ•ª‚ğİ’è‚·‚é
     *
     * @param frkskbn Uæ‹æ•ª
     */
    public void setFrkskbn(String frkskbn) {
        this._frkskbn = frkskbn;
    }

    /**
     * ‰c‹Æ”ïx•¥æ‹æ•ª‚ğæ“¾‚·‚é
     *
     * @return ‰c‹Æ”ïx•¥æ‹æ•ª
     */
    public String getEghishrskbn() {
        return _eghishrskbn;
    }

    /**
     * ‰c‹Æ”ïx•¥æ‹æ•ª‚ğİ’è‚·‚é
     *
     * @param eghishrskbn ‰c‹Æ”ïx•¥æ‹æ•ª
     */
    public void setEghishrskbn(String eghishrskbn) {
        this._eghishrskbn = eghishrskbn;
    }

    /**
     * İ’èx•¥æ‹æ•ª‚ğæ“¾‚·‚é
     *
     * @return İ’èx•¥æ‹æ•ª
     */
    public String getStyshrskbn() {
        return _styshrskbn;
    }

    /**
     * İ’èx•¥æ‹æ•ª‚ğİ’è‚·‚é
     *
     * @param styshrskbn İ’èx•¥æ‹æ•ª
     */
    public void setStyshrskbn(String styshrskbn) {
        this._styshrskbn = styshrskbn;
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
     * x•¥ğŒ‚o‚s‚m‚m‚n‚ğæ“¾‚·‚é
     *
     * @return x•¥ğŒ‚o‚s‚m‚m‚n
     */
    public String getShjyoknptnno() {
        return _shjyoknptnno;
    }

    /**
     * x•¥ğŒ‚o‚s‚m‚m‚n‚ğİ’è‚·‚é
     *
     * @param shjyoknptnno x•¥ğŒ‚o‚s‚m‚m‚n
     */
    public void setShjyoknptnno(String shjyoknptnno) {
        this._shjyoknptnno = shjyoknptnno;
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
     * •¥’S“–—\”õ‚ğæ“¾‚·‚é
     *
     * @return •¥’S“–—\”õ
     */
    public String getHrtntyobi() {
        return _hrtntyobi;
    }

    /**
     * •¥’S“–—\”õ‚ğİ’è‚·‚é
     *
     * @param hrtntyobi •¥’S“–—\”õ
     */
    public void setHrtntyobi(String hrtntyobi) {
        this._hrtntyobi = hrtntyobi;
    }

}
