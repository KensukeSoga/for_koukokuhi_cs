package jp.co.isid.ham.media.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.CarListVO;
import jp.co.isid.ham.common.model.FunctionControlInfoVO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlVO;
import jp.co.isid.ham.common.model.SecurityInfoVO;
import jp.co.isid.ham.common.model.Tbj12CampaignVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
*
* <P>
* キャンペーン一覧の情報を保持する.
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2012/11/30 FM h.izawa)<BR>
* </P>
* @author FM H.Izawa
*/
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindCampaignListResult extends AbstractServiceResult {

    /** キャンペーン一覧の取得 */
    private List<Tbj12CampaignVO> _cam;

    /** 車種一覧の取得 */
    private List<CarListVO> _car;

    /** 車種一覧の取得 */
    private List<Tbj12CampaignVO> _camDetail;

    /**スプレッド一覧取得*/
    private List<Mbj37DisplayControlVO> _spdControl;

    /** セキュリティInfo */
    private List<SecurityInfoVO> _secinfo;

    /** 機能制御Info */
    private List<FunctionControlInfoVO> _funcinfo;


    /**
     * キャンペーン一覧VOリストを取得します
     * @return _cam
     */
    public List<Tbj12CampaignVO> getCampaignList() {
        return _cam;
    }

    /**
     * キャンペーン一覧VOリストを設定します
     * @param _cam セットする _cam
     */
    public void setCampaignList(List<Tbj12CampaignVO> cam) {
        _cam = cam;
    }

    /**
     * 車種一覧VOリストを取得します
     * @return _car
     */
    public List<CarListVO> getCarList() {
        return _car;
    }

    /**
     * 車種一覧VOリストを設定します
     * @param _car セットする _car
     */
    public void setCarList(List<CarListVO> car) {
        _car = car;
    }

    /**
     * キャンペーン一覧と詳細が紐髄ているデータを取得します
     * @return _camDetail
     */
    public List<Tbj12CampaignVO> get_camDetail() {
        return _camDetail;
    }

    /**
     * キャンペーン一覧と詳細が紐髄ているデータを設定します
     * @param _camDetail セットする _camDetail
     */
    public void set_camDetail(List<Tbj12CampaignVO> _camDetail) {
        this._camDetail = _camDetail;
    }

    /**
     *スプレッド一覧VOリストを取得します
     * @return _cam
     */
    public List<Mbj37DisplayControlVO> getSpdControl() {
        return _spdControl;
    }

    /**
     *スプレッド一覧VOリストを設定します
     * @param _cam セットする _cam
     */
    public void setSpdControl(List<Mbj37DisplayControlVO> spdControl) {
        _spdControl = spdControl;
    }

    /**
     * セキュリティInfoVOリストを取得する
     * @return セキュリティInfoVOリスト
     */
    public List<SecurityInfoVO> getSecurityInfoVoList() {
        return _secinfo;
    }

    /**
     * セキュリティInfoVOリストを設定する
     * @param secinfo セキュリティInfoVOリスト
     */
    public void setSecurityInfoVoList(List<SecurityInfoVO> secinfo) {
        _secinfo = secinfo;
    }

    /**
     * 機能制御InfoVOリストを取得する
     * @return 機能制御InfoVOリスト
     */
    public List<FunctionControlInfoVO> getFunctionControlInfoVoList() {
        return _funcinfo;
    }

    /**
     * 機能制御InfoVOリストを設定する
     * @param secinfo 機能制御InfoVOリスト
     */
    public void setFunctionControlInfoVoList(List<FunctionControlInfoVO> funcinfo) {
        _funcinfo = funcinfo;
    }

    /** ListだけではWebサービスに公開されないのでダミープロパティを追加 */
    private String _dummy;

    /**
     * ListだけではWebサービスに公開されないのでダミープロパティを追加を取得します
     * @return String ダミープロパティ
     */
    public String getDummy() {
        return _dummy;
    }

    /**
     * ListだけではWebサービスに公開されないのでダミープロパティを追加を設定します
     * @param dummy ダミープロパティ
     */
    public void setDummy(String dummy) {
        this._dummy = dummy;
    }

}
