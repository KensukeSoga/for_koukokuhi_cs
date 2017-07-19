package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj20CarCategory;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 車種カテゴリマスタVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj20CarCategoryVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public Mbj20CarCategoryVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new Mbj20CarCategoryVO();
    }

    /**
     * フェイズを取得する
     *
     * @return フェイズ
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPHASE() {
        return (BigDecimal) get(Mbj20CarCategory.PHASE);
    }

    /**
     * フェイズを設定する
     *
     * @param val フェイズ
     */
    public void setPHASE(BigDecimal val) {
        set(Mbj20CarCategory.PHASE, val);
    }

    /**
     * カテゴリナンバーを取得する
     *
     * @return カテゴリナンバー
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getCATEGORYNO() {
        return (BigDecimal) get(Mbj20CarCategory.CATEGORYNO);
    }

    /**
     * カテゴリナンバーを設定する
     *
     * @param val カテゴリナンバー
     */
    public void setCATEGORYNO(BigDecimal val) {
        set(Mbj20CarCategory.CATEGORYNO, val);
    }

    /**
     * カテゴリ名を取得する
     *
     * @return カテゴリ名
     */
    public String getCATEGORYNM() {
        return (String) get(Mbj20CarCategory.CATEGORYNM);
    }

    /**
     * カテゴリ名を設定する
     *
     * @param val カテゴリ名
     */
    public void setCATEGORYNM(String val) {
        set(Mbj20CarCategory.CATEGORYNM, val);
    }

    /**
     * ソートNoを取得する
     *
     * @return ソートNo
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSORTNO() {
        return (BigDecimal) get(Mbj20CarCategory.SORTNO);
    }

    /**
     * ソートNoを設定する
     *
     * @param val ソートNo
     */
    public void setSORTNO(BigDecimal val) {
        set(Mbj20CarCategory.SORTNO, val);
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Mbj20CarCategory.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     *
     * @param val データ更新日時
     */
    public void setUPDDATE(Date val) {
        set(Mbj20CarCategory.UPDDATE, val);
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUPDNM() {
        return (String) get(Mbj20CarCategory.UPDNM);
    }

    /**
     * データ更新者を設定する
     *
     * @param val データ更新者
     */
    public void setUPDNM(String val) {
        set(Mbj20CarCategory.UPDNM, val);
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUPDAPL() {
        return (String) get(Mbj20CarCategory.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     *
     * @param val 更新プログラム
     */
    public void setUPDAPL(String val) {
        set(Mbj20CarCategory.UPDAPL, val);
    }

    /**
     * 更新担当者IDを取得する
     *
     * @return 更新担当者ID
     */
    public String getUPDID() {
        return (String) get(Mbj20CarCategory.UPDID);
    }

    /**
     * 更新担当者IDを設定する
     *
     * @param val 更新担当者ID
     */
    public void setUPDID(String val) {
        set(Mbj20CarCategory.UPDID, val);
    }

}
