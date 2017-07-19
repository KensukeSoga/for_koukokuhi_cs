package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Tbj16ContractInfo;
import jp.co.isid.ham.integ.tbl.Tbj18SozaiKanriData;
import jp.co.isid.ham.integ.tbl.Tbj20SozaiKanriList;
import jp.co.isid.ham.integ.tbl.Tbj37RdProgram;
import jp.co.isid.ham.integ.tbl.Tbj38RdProgramMaterial;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * JASRAC申請書(ラジオタイム)検索VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/11/18 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindJasracRadioTimeVO extends AbstractModel {

    /** 件数 */
    private static final String CNT = "CNT";

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public FindJasracRadioTimeVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    @Override
    public Object newInstance() {
        return new FindJasracRadioTimeVO();
    }

    /**
     * 契約コードを取得する
     * @return String 契約コード
     */
    public String getCTRTNO() {
        return (String) get(Tbj16ContractInfo.CTRTNO);
    }

    /**
     * 契約コードを設定する
     * @param val String 契約コード
     */
    public void setCTRTNO(String val) {
        set(Tbj16ContractInfo.CTRTNO, val);
    }

    /**
     * 車種コードを取得する
     * @return String 車種コード
     */
    public String getDCARCD() {
        return (String) get(Tbj20SozaiKanriList.DCARCD);
    }

    /**
     * 車種コードを設定する
     * @param val String 車種コード
     */
    public void setDCARCD(String val) {
        set(Tbj20SozaiKanriList.DCARCD, val);
    }

    /**
     * 車種名を取得する
     * @return String 車種名
     */
    public String getCARNM() {
        return (String) get(Mbj05Car.CARNM);
    }

    /**
     * 車種名を設定する
     * @param val String 車種名
     */
    public void setCARNM(String val) {
        set(Mbj05Car.CARNM, val);
    }

    /**
     * カテゴリを取得する
     * @return String カテゴリ
     */
    public String getCATEGORY() {
        return (String) get(Tbj16ContractInfo.CATEGORY);
    }

    /**
     * カテゴリを設定する
     * @param val String カテゴリ
     */
    public void setCATEGORY(String val) {
        set(Tbj16ContractInfo.CATEGORY, val);
    }

    /**
     * 楽曲名を取得する
     * @return String 楽曲名
     */
    public String getMUSIC() {
        return (String) get(Tbj16ContractInfo.MUSIC);
    }

    /**
     * 楽曲名を設定する
     * @param val String 楽曲名
     */
    public void setMUSIC(String val) {
        set(Tbj16ContractInfo.MUSIC, val);
    }

    /**
     * 名称を取得する
     * @return String 名称
     */
    public String getNAMES() {
        return (String) get(Tbj16ContractInfo.NAMES);
    }

    /**
     * 名称を設定する
     * @param val String 名称
     */
    public void setNAMES(String val) {
        set(Tbj16ContractInfo.NAMES, val);
    }

    /**
     * ラジオ番組SEQNOを取得する
     * @return BigDecimal ラジオ番組SEQNO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getRDSEQNO() {
        return (BigDecimal) get(Tbj38RdProgramMaterial.RDSEQNO);
    }

    /**
     * ラジオ番組SEQNOを設定する
     * @param val BigDecimal ラジオ番組SEQNO
     */
    public void setRDSEQNO(BigDecimal val) {
        set(Tbj38RdProgramMaterial.RDSEQNO, val);
    }

    /**
     * キー局コードを取得する
     * @return String キー局コード
     */
    public String getKEYSTATIONCD() {
        return (String) get(Tbj37RdProgram.KEYSTATIONCD);
    }

    /**
     * キー局コードを設定する
     * @param val String キー局コード
     */
    public void setKEYSTATIONCD(String val) {
        set(Tbj37RdProgram.KEYSTATIONCD, val);
    }

    /**
     * 年月を取得する
     * @return String 年月
     */
    public String getYEARMONTH() {
        return (String) get(Tbj38RdProgramMaterial.YEARMONTH);
    }

    /**
     * 年月を設定する
     * @param val String 年月
     */
    public void setYEARMONTH(String val) {
        set(Tbj38RdProgramMaterial.YEARMONTH, val);
    }

    /**
     * 10桁CMコードを取得する
     * @return String 10桁CMコード
     */
    public String getCMCD() {
        return (String) get(Tbj18SozaiKanriData.CMCD);
    }

    /**
     * 10桁CMコードを設定する
     * @param val String 10桁CMコード
     */
    public void setCMCD(String val) {
        set(Tbj18SozaiKanriData.CMCD, val);
    }

    /**
     * 売上提供料金区分を取得する
     * @return String 売上提供料金区分
     */
    public String getSALESPRICEDIV() {
        return (String) get(Tbj37RdProgram.SALESPRICEDIV);
    }

    /**
     * 売上提供料金区分を設定する
     * @param val String 売上提供料金区分
     */
    public void setSALESPRICEDIV(String val) {
        set(Tbj37RdProgram.SALESPRICEDIV, val);
    }

    /**
     * 売上提供料金を取得する
     * @return BigDecimal 売上提供料金
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSALESPRICE() {
        return (BigDecimal) get(Tbj37RdProgram.SALESPRICE);
    }

    /**
     * 売上提供料金を設定する
     * @param val BigDecimal 売上提供料金
     */
    public void setSALESPRICE(BigDecimal val) {
        set(Tbj37RdProgram.SALESPRICE, val);
    }

    /**
     * 秒数を取得する
     * @return String 秒数
     */
    public String getSECOND() {
        return (String) get(Tbj20SozaiKanriList.SECOND);
    }

    /**
     * 秒数を設定する
     * @param val String 秒数
     */
    public void setSECOND(String val) {
        set(Tbj20SozaiKanriList.SECOND, val);
    }

    /**
     * 件数を取得する
     * @return BigDecimal 件数
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getCNT() {
        return (BigDecimal) get(CNT);
    }

    /**
     * 件数を設定する
     * @param val BigDecimal 件数
     */
    public void setCNT(BigDecimal val) {
        set(CNT, val);
    }

}
