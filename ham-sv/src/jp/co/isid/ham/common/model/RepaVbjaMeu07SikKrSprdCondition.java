package jp.co.isid.ham.common.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 経理組織展開テーブル検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class RepaVbjaMeu07SikKrSprdCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 組織コード */
    private String _sikcd = null;

    /** 有効終了年月日 */
    private String _endymd = null;

    /** 有効開始年月日 */
    private String _startymd = null;

    /** 経理階層コード */
    private String _krikaisocd = null;

    /** 経理上位組織コード */
    private String _krijsikcd = null;

    /** 直轄区分 */
    private String _ckatukbn = null;

    /** 受注登録区分 */
    private String _jytrkkbn = null;

    /** 発注登録区分 */
    private String _odrtrkkbn = null;

    /** 管理部門 */
    private String _knribmon = null;

    /** 会社取引先コード */
    private String _kshathscd = null;

    /** 会社取引先ＳＥＱＮＯ */
    private String _kshathsseqno = null;

    /** 旧取引先コード */
    private String _kyutrcd = null;

    /** 媒直区分 */
    private String _bckkbn = null;

    /** 営業所コード */
    private String _egsyocd = null;

    /** 表示順 */
    private String _showno = null;

    /** 上位組織内表示順 */
    private String _jsikhyojijun = null;

    /** 表示名（カナ） */
    private String _hyojikn = null;

    /** 表示名（漢字） */
    private String _hyojikj = null;

    /** 表示略称 */
    private String _hyojiryaku = null;

    /** 表示名（英字） */
    private String _hyojien = null;

    /** 会社識別コード */
    private String _kshaskbtucd = null;

    /** 入出力コード */
    private String _iocd = null;

    /** 特殊用途コード */
    private String _spusecd = null;

    /** 組織コード（本部） */
    private String _sikcdhonb = null;

    /** 本部表示名（カナ） */
    private String _honbhyojikn = null;

    /** 本部表示名（漢字） */
    private String _honbhyojikj = null;

    /** 本部表示略称 */
    private String _honbhyojiryaku = null;

    /** 本部表示名（英字） */
    private String _honbhyojien = null;

    /** 組織コード（局） */
    private String _sikcdkyk = null;

    /** 局表示名（カナ） */
    private String _kykhyojikn = null;

    /** 局表示名（漢字） */
    private String _kykhyojikj = null;

    /** 局表示略称 */
    private String _kykhyojiryaku = null;

    /** 局表示名（英字） */
    private String _kykhyojien = null;

    /** 組織コード（室） */
    private String _sikcdsitu = null;

    /** 室表示名（カナ） */
    private String _situhyojikn = null;

    /** 室表示名（漢字） */
    private String _situhyojikj = null;

    /** 室表示略称 */
    private String _situhyojiryaku = null;

    /** 室表示名（英字） */
    private String _situhyojien = null;

    /** 組織コード（部） */
    private String _sikcdbu = null;

    /** 部表示名（カナ） */
    private String _buhyojikn = null;

    /** 部表示名（漢字） */
    private String _buhyojikj = null;

    /** 部表示略称 */
    private String _buhyojiryaku = null;

    /** 部表示名（英字） */
    private String _buhyojien = null;

    /** 組織コード（課） */
    private String _sikcdka = null;

    /** 課表示名（カナ） */
    private String _kahyojikn = null;

    /** 課表示名（漢字） */
    private String _kahyojikj = null;

    /** 課表示略称 */
    private String _kahyojiryaku = null;

    /** 課表示名（英字） */
    private String _kahyojien = null;

    /**
     * デフォルトコンストラクタ
     */
    public RepaVbjaMeu07SikKrSprdCondition() {
    }

    /**
     * 組織コードを取得する
     *
     * @return 組織コード
     */
    public String getSikcd() {
        return _sikcd;
    }

    /**
     * 組織コードを設定する
     *
     * @param sikcd 組織コード
     */
    public void setSikcd(String sikcd) {
        this._sikcd = sikcd;
    }

    /**
     * 有効終了年月日を取得する
     *
     * @return 有効終了年月日
     */
    public String getEndymd() {
        return _endymd;
    }

    /**
     * 有効終了年月日を設定する
     *
     * @param endymd 有効終了年月日
     */
    public void setEndymd(String endymd) {
        this._endymd = endymd;
    }

    /**
     * 有効開始年月日を取得する
     *
     * @return 有効開始年月日
     */
    public String getStartymd() {
        return _startymd;
    }

    /**
     * 有効開始年月日を設定する
     *
     * @param startymd 有効開始年月日
     */
    public void setStartymd(String startymd) {
        this._startymd = startymd;
    }

    /**
     * 経理階層コードを取得する
     *
     * @return 経理階層コード
     */
    public String getKrikaisocd() {
        return _krikaisocd;
    }

    /**
     * 経理階層コードを設定する
     *
     * @param krikaisocd 経理階層コード
     */
    public void setKrikaisocd(String krikaisocd) {
        this._krikaisocd = krikaisocd;
    }

    /**
     * 経理上位組織コードを取得する
     *
     * @return 経理上位組織コード
     */
    public String getKrijsikcd() {
        return _krijsikcd;
    }

    /**
     * 経理上位組織コードを設定する
     *
     * @param krijsikcd 経理上位組織コード
     */
    public void setKrijsikcd(String krijsikcd) {
        this._krijsikcd = krijsikcd;
    }

    /**
     * 直轄区分を取得する
     *
     * @return 直轄区分
     */
    public String getCkatukbn() {
        return _ckatukbn;
    }

    /**
     * 直轄区分を設定する
     *
     * @param ckatukbn 直轄区分
     */
    public void setCkatukbn(String ckatukbn) {
        this._ckatukbn = ckatukbn;
    }

    /**
     * 受注登録区分を取得する
     *
     * @return 受注登録区分
     */
    public String getJytrkkbn() {
        return _jytrkkbn;
    }

    /**
     * 受注登録区分を設定する
     *
     * @param jytrkkbn 受注登録区分
     */
    public void setJytrkkbn(String jytrkkbn) {
        this._jytrkkbn = jytrkkbn;
    }

    /**
     * 発注登録区分を取得する
     *
     * @return 発注登録区分
     */
    public String getOdrtrkkbn() {
        return _odrtrkkbn;
    }

    /**
     * 発注登録区分を設定する
     *
     * @param odrtrkkbn 発注登録区分
     */
    public void setOdrtrkkbn(String odrtrkkbn) {
        this._odrtrkkbn = odrtrkkbn;
    }

    /**
     * 管理部門を取得する
     *
     * @return 管理部門
     */
    public String getKnribmon() {
        return _knribmon;
    }

    /**
     * 管理部門を設定する
     *
     * @param knribmon 管理部門
     */
    public void setKnribmon(String knribmon) {
        this._knribmon = knribmon;
    }

    /**
     * 会社取引先コードを取得する
     *
     * @return 会社取引先コード
     */
    public String getKshathscd() {
        return _kshathscd;
    }

    /**
     * 会社取引先コードを設定する
     *
     * @param kshathscd 会社取引先コード
     */
    public void setKshathscd(String kshathscd) {
        this._kshathscd = kshathscd;
    }

    /**
     * 会社取引先ＳＥＱＮＯを取得する
     *
     * @return 会社取引先ＳＥＱＮＯ
     */
    public String getKshathsseqno() {
        return _kshathsseqno;
    }

    /**
     * 会社取引先ＳＥＱＮＯを設定する
     *
     * @param kshathsseqno 会社取引先ＳＥＱＮＯ
     */
    public void setKshathsseqno(String kshathsseqno) {
        this._kshathsseqno = kshathsseqno;
    }

    /**
     * 旧取引先コードを取得する
     *
     * @return 旧取引先コード
     */
    public String getKyutrcd() {
        return _kyutrcd;
    }

    /**
     * 旧取引先コードを設定する
     *
     * @param kyutrcd 旧取引先コード
     */
    public void setKyutrcd(String kyutrcd) {
        this._kyutrcd = kyutrcd;
    }

    /**
     * 媒直区分を取得する
     *
     * @return 媒直区分
     */
    public String getBckkbn() {
        return _bckkbn;
    }

    /**
     * 媒直区分を設定する
     *
     * @param bckkbn 媒直区分
     */
    public void setBckkbn(String bckkbn) {
        this._bckkbn = bckkbn;
    }

    /**
     * 営業所コードを取得する
     *
     * @return 営業所コード
     */
    public String getEgsyocd() {
        return _egsyocd;
    }

    /**
     * 営業所コードを設定する
     *
     * @param egsyocd 営業所コード
     */
    public void setEgsyocd(String egsyocd) {
        this._egsyocd = egsyocd;
    }

    /**
     * 表示順を取得する
     *
     * @return 表示順
     */
    public String getShowno() {
        return _showno;
    }

    /**
     * 表示順を設定する
     *
     * @param showno 表示順
     */
    public void setShowno(String showno) {
        this._showno = showno;
    }

    /**
     * 上位組織内表示順を取得する
     *
     * @return 上位組織内表示順
     */
    public String getJsikhyojijun() {
        return _jsikhyojijun;
    }

    /**
     * 上位組織内表示順を設定する
     *
     * @param jsikhyojijun 上位組織内表示順
     */
    public void setJsikhyojijun(String jsikhyojijun) {
        this._jsikhyojijun = jsikhyojijun;
    }

    /**
     * 表示名（カナ）を取得する
     *
     * @return 表示名（カナ）
     */
    public String getHyojikn() {
        return _hyojikn;
    }

    /**
     * 表示名（カナ）を設定する
     *
     * @param hyojikn 表示名（カナ）
     */
    public void setHyojikn(String hyojikn) {
        this._hyojikn = hyojikn;
    }

    /**
     * 表示名（漢字）を取得する
     *
     * @return 表示名（漢字）
     */
    public String getHyojikj() {
        return _hyojikj;
    }

    /**
     * 表示名（漢字）を設定する
     *
     * @param hyojikj 表示名（漢字）
     */
    public void setHyojikj(String hyojikj) {
        this._hyojikj = hyojikj;
    }

    /**
     * 表示略称を取得する
     *
     * @return 表示略称
     */
    public String getHyojiryaku() {
        return _hyojiryaku;
    }

    /**
     * 表示略称を設定する
     *
     * @param hyojiryaku 表示略称
     */
    public void setHyojiryaku(String hyojiryaku) {
        this._hyojiryaku = hyojiryaku;
    }

    /**
     * 表示名（英字）を取得する
     *
     * @return 表示名（英字）
     */
    public String getHyojien() {
        return _hyojien;
    }

    /**
     * 表示名（英字）を設定する
     *
     * @param hyojien 表示名（英字）
     */
    public void setHyojien(String hyojien) {
        this._hyojien = hyojien;
    }

    /**
     * 会社識別コードを取得する
     *
     * @return 会社識別コード
     */
    public String getKshaskbtucd() {
        return _kshaskbtucd;
    }

    /**
     * 会社識別コードを設定する
     *
     * @param kshaskbtucd 会社識別コード
     */
    public void setKshaskbtucd(String kshaskbtucd) {
        this._kshaskbtucd = kshaskbtucd;
    }

    /**
     * 入出力コードを取得する
     *
     * @return 入出力コード
     */
    public String getIocd() {
        return _iocd;
    }

    /**
     * 入出力コードを設定する
     *
     * @param iocd 入出力コード
     */
    public void setIocd(String iocd) {
        this._iocd = iocd;
    }

    /**
     * 特殊用途コードを取得する
     *
     * @return 特殊用途コード
     */
    public String getSpusecd() {
        return _spusecd;
    }

    /**
     * 特殊用途コードを設定する
     *
     * @param spusecd 特殊用途コード
     */
    public void setSpusecd(String spusecd) {
        this._spusecd = spusecd;
    }

    /**
     * 組織コード（本部）を取得する
     *
     * @return 組織コード（本部）
     */
    public String getSikcdhonb() {
        return _sikcdhonb;
    }

    /**
     * 組織コード（本部）を設定する
     *
     * @param sikcdhonb 組織コード（本部）
     */
    public void setSikcdhonb(String sikcdhonb) {
        this._sikcdhonb = sikcdhonb;
    }

    /**
     * 本部表示名（カナ）を取得する
     *
     * @return 本部表示名（カナ）
     */
    public String getHonbhyojikn() {
        return _honbhyojikn;
    }

    /**
     * 本部表示名（カナ）を設定する
     *
     * @param honbhyojikn 本部表示名（カナ）
     */
    public void setHonbhyojikn(String honbhyojikn) {
        this._honbhyojikn = honbhyojikn;
    }

    /**
     * 本部表示名（漢字）を取得する
     *
     * @return 本部表示名（漢字）
     */
    public String getHonbhyojikj() {
        return _honbhyojikj;
    }

    /**
     * 本部表示名（漢字）を設定する
     *
     * @param honbhyojikj 本部表示名（漢字）
     */
    public void setHonbhyojikj(String honbhyojikj) {
        this._honbhyojikj = honbhyojikj;
    }

    /**
     * 本部表示略称を取得する
     *
     * @return 本部表示略称
     */
    public String getHonbhyojiryaku() {
        return _honbhyojiryaku;
    }

    /**
     * 本部表示略称を設定する
     *
     * @param honbhyojiryaku 本部表示略称
     */
    public void setHonbhyojiryaku(String honbhyojiryaku) {
        this._honbhyojiryaku = honbhyojiryaku;
    }

    /**
     * 本部表示名（英字）を取得する
     *
     * @return 本部表示名（英字）
     */
    public String getHonbhyojien() {
        return _honbhyojien;
    }

    /**
     * 本部表示名（英字）を設定する
     *
     * @param honbhyojien 本部表示名（英字）
     */
    public void setHonbhyojien(String honbhyojien) {
        this._honbhyojien = honbhyojien;
    }

    /**
     * 組織コード（局）を取得する
     *
     * @return 組織コード（局）
     */
    public String getSikcdkyk() {
        return _sikcdkyk;
    }

    /**
     * 組織コード（局）を設定する
     *
     * @param sikcdkyk 組織コード（局）
     */
    public void setSikcdkyk(String sikcdkyk) {
        this._sikcdkyk = sikcdkyk;
    }

    /**
     * 局表示名（カナ）を取得する
     *
     * @return 局表示名（カナ）
     */
    public String getKykhyojikn() {
        return _kykhyojikn;
    }

    /**
     * 局表示名（カナ）を設定する
     *
     * @param kykhyojikn 局表示名（カナ）
     */
    public void setKykhyojikn(String kykhyojikn) {
        this._kykhyojikn = kykhyojikn;
    }

    /**
     * 局表示名（漢字）を取得する
     *
     * @return 局表示名（漢字）
     */
    public String getKykhyojikj() {
        return _kykhyojikj;
    }

    /**
     * 局表示名（漢字）を設定する
     *
     * @param kykhyojikj 局表示名（漢字）
     */
    public void setKykhyojikj(String kykhyojikj) {
        this._kykhyojikj = kykhyojikj;
    }

    /**
     * 局表示略称を取得する
     *
     * @return 局表示略称
     */
    public String getKykhyojiryaku() {
        return _kykhyojiryaku;
    }

    /**
     * 局表示略称を設定する
     *
     * @param kykhyojiryaku 局表示略称
     */
    public void setKykhyojiryaku(String kykhyojiryaku) {
        this._kykhyojiryaku = kykhyojiryaku;
    }

    /**
     * 局表示名（英字）を取得する
     *
     * @return 局表示名（英字）
     */
    public String getKykhyojien() {
        return _kykhyojien;
    }

    /**
     * 局表示名（英字）を設定する
     *
     * @param kykhyojien 局表示名（英字）
     */
    public void setKykhyojien(String kykhyojien) {
        this._kykhyojien = kykhyojien;
    }

    /**
     * 組織コード（室）を取得する
     *
     * @return 組織コード（室）
     */
    public String getSikcdsitu() {
        return _sikcdsitu;
    }

    /**
     * 組織コード（室）を設定する
     *
     * @param sikcdsitu 組織コード（室）
     */
    public void setSikcdsitu(String sikcdsitu) {
        this._sikcdsitu = sikcdsitu;
    }

    /**
     * 室表示名（カナ）を取得する
     *
     * @return 室表示名（カナ）
     */
    public String getSituhyojikn() {
        return _situhyojikn;
    }

    /**
     * 室表示名（カナ）を設定する
     *
     * @param situhyojikn 室表示名（カナ）
     */
    public void setSituhyojikn(String situhyojikn) {
        this._situhyojikn = situhyojikn;
    }

    /**
     * 室表示名（漢字）を取得する
     *
     * @return 室表示名（漢字）
     */
    public String getSituhyojikj() {
        return _situhyojikj;
    }

    /**
     * 室表示名（漢字）を設定する
     *
     * @param situhyojikj 室表示名（漢字）
     */
    public void setSituhyojikj(String situhyojikj) {
        this._situhyojikj = situhyojikj;
    }

    /**
     * 室表示略称を取得する
     *
     * @return 室表示略称
     */
    public String getSituhyojiryaku() {
        return _situhyojiryaku;
    }

    /**
     * 室表示略称を設定する
     *
     * @param situhyojiryaku 室表示略称
     */
    public void setSituhyojiryaku(String situhyojiryaku) {
        this._situhyojiryaku = situhyojiryaku;
    }

    /**
     * 室表示名（英字）を取得する
     *
     * @return 室表示名（英字）
     */
    public String getSituhyojien() {
        return _situhyojien;
    }

    /**
     * 室表示名（英字）を設定する
     *
     * @param situhyojien 室表示名（英字）
     */
    public void setSituhyojien(String situhyojien) {
        this._situhyojien = situhyojien;
    }

    /**
     * 組織コード（部）を取得する
     *
     * @return 組織コード（部）
     */
    public String getSikcdbu() {
        return _sikcdbu;
    }

    /**
     * 組織コード（部）を設定する
     *
     * @param sikcdbu 組織コード（部）
     */
    public void setSikcdbu(String sikcdbu) {
        this._sikcdbu = sikcdbu;
    }

    /**
     * 部表示名（カナ）を取得する
     *
     * @return 部表示名（カナ）
     */
    public String getBuhyojikn() {
        return _buhyojikn;
    }

    /**
     * 部表示名（カナ）を設定する
     *
     * @param buhyojikn 部表示名（カナ）
     */
    public void setBuhyojikn(String buhyojikn) {
        this._buhyojikn = buhyojikn;
    }

    /**
     * 部表示名（漢字）を取得する
     *
     * @return 部表示名（漢字）
     */
    public String getBuhyojikj() {
        return _buhyojikj;
    }

    /**
     * 部表示名（漢字）を設定する
     *
     * @param buhyojikj 部表示名（漢字）
     */
    public void setBuhyojikj(String buhyojikj) {
        this._buhyojikj = buhyojikj;
    }

    /**
     * 部表示略称を取得する
     *
     * @return 部表示略称
     */
    public String getBuhyojiryaku() {
        return _buhyojiryaku;
    }

    /**
     * 部表示略称を設定する
     *
     * @param buhyojiryaku 部表示略称
     */
    public void setBuhyojiryaku(String buhyojiryaku) {
        this._buhyojiryaku = buhyojiryaku;
    }

    /**
     * 部表示名（英字）を取得する
     *
     * @return 部表示名（英字）
     */
    public String getBuhyojien() {
        return _buhyojien;
    }

    /**
     * 部表示名（英字）を設定する
     *
     * @param buhyojien 部表示名（英字）
     */
    public void setBuhyojien(String buhyojien) {
        this._buhyojien = buhyojien;
    }

    /**
     * 組織コード（課）を取得する
     *
     * @return 組織コード（課）
     */
    public String getSikcdka() {
        return _sikcdka;
    }

    /**
     * 組織コード（課）を設定する
     *
     * @param sikcdka 組織コード（課）
     */
    public void setSikcdka(String sikcdka) {
        this._sikcdka = sikcdka;
    }

    /**
     * 課表示名（カナ）を取得する
     *
     * @return 課表示名（カナ）
     */
    public String getKahyojikn() {
        return _kahyojikn;
    }

    /**
     * 課表示名（カナ）を設定する
     *
     * @param kahyojikn 課表示名（カナ）
     */
    public void setKahyojikn(String kahyojikn) {
        this._kahyojikn = kahyojikn;
    }

    /**
     * 課表示名（漢字）を取得する
     *
     * @return 課表示名（漢字）
     */
    public String getKahyojikj() {
        return _kahyojikj;
    }

    /**
     * 課表示名（漢字）を設定する
     *
     * @param kahyojikj 課表示名（漢字）
     */
    public void setKahyojikj(String kahyojikj) {
        this._kahyojikj = kahyojikj;
    }

    /**
     * 課表示略称を取得する
     *
     * @return 課表示略称
     */
    public String getKahyojiryaku() {
        return _kahyojiryaku;
    }

    /**
     * 課表示略称を設定する
     *
     * @param kahyojiryaku 課表示略称
     */
    public void setKahyojiryaku(String kahyojiryaku) {
        this._kahyojiryaku = kahyojiryaku;
    }

    /**
     * 課表示名（英字）を取得する
     *
     * @return 課表示名（英字）
     */
    public String getKahyojien() {
        return _kahyojien;
    }

    /**
     * 課表示名（英字）を設定する
     *
     * @param kahyojien 課表示名（英字）
     */
    public void setKahyojien(String kahyojien) {
        this._kahyojien = kahyojien;
    }

}
