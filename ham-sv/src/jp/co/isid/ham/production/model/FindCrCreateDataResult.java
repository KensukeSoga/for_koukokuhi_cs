package jp.co.isid.ham.production.model;

import java.util.Date;
import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Tbj10CrCarInfoVO;
import jp.co.isid.ham.common.model.Tbj11CrCreateDataVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * CR制作費　検索実行時のデータ取得の結果クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/30 新HAMチーム)<BR>
 * </P>
 *
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class FindCrCreateDataResult extends AbstractServiceResult {

    /* ============================================================================= */
    /** ListだけではWebサービスに公開されないのでダミープロパティを追加 */
    private String _dummy;

    /**
     * ListだけではWebサービスに公開されないのでダミープロパティを取得します
     *
     * @return String ダミープロパティ
     */
    public String getDummy() {
        return _dummy;
    }

    /**
     * ListだけではWebサービスに公開されないのでダミープロパティを設定します
     *
     * @param dummy ダミープロパティ
     */
    public void setDummy(String dummy) {
        this._dummy = dummy;
    }

    /* ============================================================================= */

    /** CR車種情報VOリスト */
    private List<Tbj10CrCarInfoVO> _tbj10CrCarInfoVoList = null;

    /** CR制作費管理VOリスト */
    private List<Tbj11CrCreateDataVO> _tbj11CrCreateDataVoList = null;

    /** CR車種情報の最大タイムスタンプ */
    private Date _maxDateTimeForCrCarInfo = null;

    /** CR制作費管理の最大タイムスタンプ */
    private Date _maxDateTimeForCrCreateData = null;

    /** 請求先データVOリスト */
    private List<SeikyuDataVO> _seikyuDataVoList = null;

    /** 支払先データVOリスト */
    private List<PayDataVO> _payDataVoList = null;

    /**
     * CR車種情報VOリストを取得する
     *
     * @return CR車種情報VOリスト
     */
    public List<Tbj10CrCarInfoVO> getTbj10CrCarInfoVoList() {
        return _tbj10CrCarInfoVoList;
    }

    /**
     * CR車種情報VOリストを設定する
     *
     * @param tbj10CrCarInfoVoList CR車種情報VOリスト
     */
    public void setTbj10CrCarInfoVoList(List<Tbj10CrCarInfoVO> tbj10CrCarInfoVoList) {
        this._tbj10CrCarInfoVoList = tbj10CrCarInfoVoList;
    }

    /**
     * CR制作費管理VOリストを取得する
     *
     * @return CR制作費管理VOリスト
     */
    public List<Tbj11CrCreateDataVO> getTbj11CrCreateDataVoList() {
        return _tbj11CrCreateDataVoList;
    }

    /**
     * CR制作費管理VOリストを設定する
     *
     * @param tbj11CrCreateDataVoList CR制作費管理VOリスト
     */
    public void setTbj11CrCreateDataVoList(List<Tbj11CrCreateDataVO> tbj11CrCreateDataVoList) {
        this._tbj11CrCreateDataVoList = tbj11CrCreateDataVoList;
    }

    /**
     * CR車種情報のタイムスタンプ最大値を取得する
     *
     * @return CR車種情報のタイムスタンプ最大値
     */
    public Date getMaxDateTimeForCrCarInfo() {
        return _maxDateTimeForCrCarInfo;
    }

    /**
     * CR車種情報のタイムスタンプ最大値を設定する
     *
     * @param maxDateTimeForCrCarInfo CR制作費管理のタイムスタンプ最大値
     */
    public void setMaxDateTimeForCrCarInfo(Date maxDateTimeForCrCarInfo) {
        this._maxDateTimeForCrCarInfo = maxDateTimeForCrCarInfo;
    }

    /**
     * CR制作費管理のタイムスタンプ最大値を取得する
     *
     * @return CR制作費管理のタイムスタンプ最大値
     */
    public Date getMaxDateTimeForCrCreateData() {
        return _maxDateTimeForCrCreateData;
    }

    /**
     * CR制作費管理のタイムスタンプ最大値を設定する
     *
     * @param maxDateTimeForCrCarInfo CR制作費管理のタイムスタンプ最大値
     */
    public void setMaxDateTimeForCrCreateData(Date maxDateTimeForCrCreateData) {
        this._maxDateTimeForCrCreateData = maxDateTimeForCrCreateData;
    }

    /**
     * 請求先データVOリストを取得する
     *
     * @return 請求先データVOリスト
     */
    public List<SeikyuDataVO> getSeikyuDataVoList() {
        return _seikyuDataVoList;
    }

    /**
     * 請求先データVOリストを設定する
     *
     * @param seikyuDataVoList 請求先データVOリスト
     */
    public void setSeikyuDataVoList(List<SeikyuDataVO> seikyuDataVoList) {
        this._seikyuDataVoList = seikyuDataVoList;
    }

    /**
     * 支払先データVOリストを取得する
     *
     * @return 支払先データVOリスト
     */
    public List<PayDataVO> getPayDataVoList() {
        return _payDataVoList;
    }

    /**
     * 支払先データVOリストを設定する
     *
     * @param payDataVoList 支払先データVOリスト
     */
    public void setPayDataVoList(List<PayDataVO> payDataVoList) {
        this._payDataVoList = payDataVoList;
    }

}
