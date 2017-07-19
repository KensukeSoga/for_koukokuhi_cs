package jp.co.isid.ham.media.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj03Media;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj50RdStation;
import jp.co.isid.ham.integ.tbl.Tbj17Content;
import jp.co.isid.ham.integ.tbl.Tbj20SozaiKanriList;
import jp.co.isid.ham.integ.tbl.Tbj37RdProgram;
import jp.co.isid.ham.integ.tbl.Tbj38RdProgramMaterial;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 営業作業台帳ラジオタイムインポート情報検索VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/12/11 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindRdTime2AccountBookVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 件数 */
    public static final String CNT = "CNT";

    /**
     * デフォルトコンストラクタ
     */
    public FindRdTime2AccountBookVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new FindRdTime2AccountBookVO();
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
        set(Tbj38RdProgramMaterial  .RDSEQNO, val);
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
     * 系列コードを取得する
     * @return String 系列コード
     */
    public String getKEIRETSUCD() {
        return (String) get(Mbj05Car.KEIRETSUCD);
    }

    /**
     * 系列コードを設定する
     * @param val String 系列コード
     */
    public void setKEIRETSUCD(String val) {
        set(Mbj05Car.KEIRETSUCD, val);
    }

    /**
     * 放送局名を取得する
     * @return String 放送局名
     */
    public String getRDSTATION() {
        return (String) get(Mbj50RdStation.ABBREVIATION);
    }

    /**
     * 放送局名を設定する
     * @param val String 放送局名
     */
    public void setRDSTATION(String val) {
        set(Mbj50RdStation.ABBREVIATION, val);
    }

    /**
     * 番組名を取得する
     * @return String 番組名
     */
    public String getPROGRAMNM() {
        return (String) get(Tbj37RdProgram.PROGRAMNM);
    }

    /**
     * 番組名を設定する
     * @param val String 番組名
     */
    public void setPROGRAMNM(String val) {
        set(Tbj37RdProgram.PROGRAMNM, val);
    }

    /**
     * 媒体名称を取得する
     * @return String 媒体名称
     */
    public String getMEDIANM() {
       return (String) get(Mbj03Media.MEDIANM);
    }

    /**
     * 媒体名称を設定する
     * @param val String 媒体名称
     */
    public void setMEDIANM(String val) {
        set(Mbj03Media.MEDIANM, val);
    }

    /**
     * 10桁CMコードを取得する
     * @return String 10桁CMコード
     */
    public String getCMCD() {
        return (String) get(Tbj17Content.CMCD);
    }

    /**
     * 10桁CMコードを設定する
     * @param val String 10桁CMコード
     */
    public void setCMCD(String val) {
        set(Tbj17Content.CMCD, val);
    }

    /**
     * 略コードを取得する
     * @return String 略コード
     */
    public String getRCODE() {
        return (String) get(Tbj20SozaiKanriList.RCODE);
    }

    /**
     * 略コードを設定する
     * @param val String 略コード
     */
    public void setRCODE(String val) {
        set(Tbj20SozaiKanriList.RCODE, val);
    }

    /**
     * 秒数を取得する
     * @return BigDecimal 秒数
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSECOND() {
        return (BigDecimal) get(Tbj20SozaiKanriList.SECOND);
    }

    /**
     * 秒数を設定する
     * @param val BigDecimal 秒数
     */
    public void setSECOND(BigDecimal val) {
        set(Tbj20SozaiKanriList.SECOND, val);
    }

    /**
     * 放送開始日を取得する
     * @return Date 放送開始日
     */
    @XmlElement(required = true, nillable = true)
    public Date getSTARTDATE() {
        return (Date) get(Tbj37RdProgram.DATEFROM);
    }

    /**
     * 放送開始日を設定する
     * @param val Date 放送開始日
     */
    public void setSTARTDATE(Date val) {
        set(Tbj37RdProgram.DATEFROM, val);
    }

    /**
     * 放送終了日を取得する
     * @return Date 放送終了日
     */
    @XmlElement(required = true, nillable = true)
    public Date getENDDATE() {
        return (Date) get(Tbj37RdProgram.DATETO);
    }

    /**
     * 放送終了日を設定する
     * @param val Date 放送終了日
     */
    public void setENDDATE(Date val) {
        set(Tbj37RdProgram.DATETO, val);
    }

    /**
     * 放送曜日を取得する
     * @return String 放送曜日
     */
    public String getONAIRDAY() {
        return (String) get(Tbj37RdProgram.ONAIRMON);
    }

    /**
     * 放送曜日を設定する
     * @param val String 放送曜日
     */
    public void setONAIRDAY(String val) {
        set(Tbj37RdProgram.ONAIRMON, val);
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
