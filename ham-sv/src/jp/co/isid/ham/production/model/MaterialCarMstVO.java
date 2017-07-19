package jp.co.isid.ham.production.model;


import java.math.BigDecimal;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj22CategoryContent;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 素材一覧用車種コードマスタVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class MaterialCarMstVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * コンストラクタ
     */
    public MaterialCarMstVO() {

    }
    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new MaterialCarMstVO();
    }

    /**
     * 電通車種コードを取得する
     *
     * @return 電通車種コード
     */
    public String getDCARCD() {
        return (String) get(Mbj05Car.DCARCD);
    }

    /**
     * 電通車種コードを設定する
     *
     * @param val 電通車種コード
     */
    public void setDCARCD(String val) {
        set(Mbj05Car.DCARCD, val);
    }

    /**
     * 車種名を取得する
     *
     * @return 車種名
     */
    public String getCARNM() {
        return (String) get(Mbj05Car.CARNM);
    }

    /**
     * 車種名を設定する
     *
     * @param val 車種名
     */
    public void setCARNM(String val) {
        set(Mbj05Car.CARNM, val);
    }

    /**
     * フェイズを取得する
     *
     * @return フェイズ
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPHASE() {
        return (BigDecimal) get(Mbj22CategoryContent.PHASE);
    }

    /**
     * フェイズを設定する
     *
     * @param val フェイズ
     */
    public void setPHASE(BigDecimal val) {
        set(Mbj22CategoryContent.PHASE, val);
    }

    /**
     * カテゴリナンバーを取得する
     *
     * @return カテゴリナンバー
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getCATEGORYNO() {
        return (BigDecimal) get(Mbj22CategoryContent.CATEGORYNO);
    }

    /**
     * カテゴリナンバーを設定する
     *
     * @param val カテゴリナンバー
     */
    public void setCATEGORYNO(BigDecimal val) {
        set(Mbj22CategoryContent.CATEGORYNO, val);
    }

}
