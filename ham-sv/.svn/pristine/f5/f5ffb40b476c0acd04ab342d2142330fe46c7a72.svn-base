package jp.co.isid.ham.billing.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 制作請求表出力データ存在チェック情報Condition
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/4/1 J.Kamiyama)<BR>
 * </P>
 * @author J.Kamiyama
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class CheckBillProductionOutputCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * フェイズ
     */
    private int _phase = 0;

    /**
     * 年月(from)
     */
    private String _yearMonthFrom = null;

    /**
     * 年月(to)
     */
    private String _yearMonthTo = null;

    /**
     * 請求先Gr.
     */
    private String _demandGroup = null;

    /**
     * 出力対象フラグ
     */
    private String _outputFlg = null;

    /**
     * 車種表示順
     */
    private String _carSort = null;

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
     * 年月(from)を取得する
     *
     * @return 年月(from)
     */
    public String getYearMonthFrom() {
        return _yearMonthFrom;
    }

    /**
     * 年月(from)を設定する
     *
     * @param yearMonthFrom 年月(from)
     */
    public void setYearMonthFrom(String yearMonthFrom) {
        _yearMonthFrom = yearMonthFrom;
    }

    /**
     * 年月(to)を取得する
     *
     * @return 年月(to)
     */
    public String getYearMonthTo() {
        return _yearMonthTo;
    }

    /**
     * 年月(to)を設定する
     *
     * @param yearMonthTo 年月(to)
     */
    public void setYearMonthTo(String yearMonthTo) {
        _yearMonthTo = yearMonthTo;
    }

    /**
     * 請求先Gr.を取得する
     *
     * @return 請求先Gr.
     */
    public String getDemandGroup() {
        return _demandGroup;
    }

    /**
     * 請求先Gr.を設定する
     *
     * @param demandGroup 請求先Gr.
     */
    public void setDemandGroup(String demandGroup) {
    	_demandGroup = demandGroup;
    }

    /**
     * 出力対象フラグを取得する
     *
     * @return 出力対象フラグ
     */
    public String getOutputFlg() {
        return _outputFlg;
    }

    /**
     * 出力対象フラグを設定する
     *
     * @param outputFlg 出力対象フラグ
     */
    public void setOutputFlg(String outputFlg) {
    	_outputFlg = outputFlg;
    }

    /**
     * 車種表示順を取得する
     *
     * @return 車種表示順
     */
    public String getCarSort() {
        return _carSort;
    }

    /**
     * 車種表示順を設定する
     *
     * @param outputFlg 車種表示順
     */
    public void setCarSort(String carSort) {
    	_carSort = carSort;
    }
}
