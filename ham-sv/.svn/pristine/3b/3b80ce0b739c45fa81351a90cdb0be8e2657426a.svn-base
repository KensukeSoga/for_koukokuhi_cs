package jp.co.isid.ham.billing.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * コスト管理表出力内容検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/4/2 HLC H.Watabe)<BR>
 * </P>
 * @author H.watabe
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindCostManagementReportCondition implements Serializable{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * フェイズ
     */
    private int _phase = 0;

    /**
     * 期間開始
     */
    private String _kikanFrom = null;

    /**
     * 期間終了
     */
    private String _kikanTo = null;

    /**
     * 料金取得フラグ
     */
    private boolean _feeGetFlg;

    /**
     * フェイズを取得する
     *
     * @return フェイズ
     */
    public int getPhase() {
        return _phase;
    }

    /**
     * フェイズを設定する
     *
     * @param phase フェイズ
     */
    public void setPhase(int phase) {
        _phase = phase;
    }

    /**
     * 期間開始を取得する
     *
     * @return 期間開始
     */
    public String getKikanFrom() {
        return _kikanFrom;
    }

    /**
     * 期間開始を設定する
     *
     * @param KikanFrom 期間開始
     */
    public void setKikanFrom(String kikanFrom) {
        _kikanFrom = kikanFrom;
    }

    /**
     * 期間終了を取得する
     *
     * @return 期間終了
     */
    public String getKikanTo() {
        return _kikanTo;
    }

    /**
     * 期間終了を設定する
     *
     * @param KikanTo 期間終了
     */
    public void setKikanTo(String kikanTo) {
        _kikanTo = kikanTo;
    }

    /**
     * 料金取得フラグを取得する
     * @return 料金取得フラグ
     */
    public boolean getFeeGetFlg() {
        return _feeGetFlg;
    }

    /**
     * 料金取得フラグを設定する
     * @param feeGetFlg 料金取得フラグ
     */
    public void setFeeGetFlg(boolean feeGetFlg) {
        _feeGetFlg = feeGetFlg;
    }
}
