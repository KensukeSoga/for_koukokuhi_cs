package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 帳票出力設定検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/01/09 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class FindExcelOutSettingCondition implements Serializable{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 帳票コード */
    private String _reportcd = null;

    /** フェイズ */
    private BigDecimal _phase = null;

    /**
     * デフォルトコンストラクタ
     */
    public FindExcelOutSettingCondition() {
    }

    /**
     * 帳票コードを取得する
     *
     * @return 帳票コード
     */
    public String getReportcd() {
        return _reportcd;
    }

    /**
     * 帳票コードを設定する
     *
     * @param reportcd 帳票コード
     */
    public void setReportcd(String reportcd) {
        this._reportcd = reportcd;
    }

    /**
     * フェイズを取得する
     *
     * @return フェイズ
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPhase() {
        return _phase;
    }

    /**
     * フェイズを設定する
     *
     * @param phase フェイズ
     */
    public void setPhase(BigDecimal phase) {
        this._phase = phase;
    }



}
