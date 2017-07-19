package jp.co.isid.ham.production.model;

import java.io.Serializable;
import java.text.SimpleDateFormat;
import java.util.Date;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * タレント・ナレーター・楽曲契約表検索(帳票用)条件クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/03/26 T.Hadate)<BR>
 * </P>
 * @author Takahiro Hadate
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class Contract4ReportCondition implements Serializable {

    /** */
    private static final long serialVersionUID = -6037535306962499837L;

    /** 日付フォーマッター */
    private static SimpleDateFormat _formatter = new SimpleDateFormat("yyyy-MM-dd");

    /** 期間開始 */
    private String _dateFrom;

    /** 期間終了 */
    private String _dateTo;

    /** 車種 */
    private String _dcarcd;

    /** 担当者ID */
    private String _hamid;

    /**
     * 期間開始を取得します
     * @return 期間開始
     */
    public String getDateFrom() {
        return _dateFrom;
    }

    /**
     * 期間開始を設定する.
     * @param dateFrom 期間開始
     */
    public void setDateFrom(String dateFrom) {
        this._dateFrom = dateFrom;
    }

    /**
     * 期間開始を設定する.
     * @param dateFrom
     */
    public void setDateFrom(Date dateFrom) {
        this._dateFrom = _formatter.format(dateFrom);
    }

    /**
     * 期間終了を取得する.
     * @return 期間終了
     */
    public String getDateTo() {
        return _dateTo;
    }

    /**
     * 期間終了を設定する.
     * @param dateTo 期間終了
     */
    public void setDateTo(String dateTo) {
        this._dateTo = dateTo;
    }

    /**
     * 期間終了を設定する.
     * @param dateTo 期間終了
     */
    public void setDateTo(Date dateTo) {
        this._dateTo = _formatter.format(dateTo);
    }

    /**
     * 車種を取得する.
     * @return 車種
     */
    public String getDcarcd() {
        return _dcarcd;
    }

    /**
     * 車種を設定する.
     * @param dcarcd 車種
     */
    public void setDcarcd(String dcarcd) {
        this._dcarcd = dcarcd;
    }

    /**
     * 担当者IDを取得する.
     * @return 担当者ID
     */
    public String getHamid() {
        return _hamid;
    }

    /**
     * 担当者IDを設定する.
     * @param hamid 担当者ID
     */
    public void setHamid(String hamid) {
        this._hamid = hamid;
    }
}
