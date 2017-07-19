package jp.co.isid.ham.media.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.FunctionControlInfoVO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlVO;
import jp.co.isid.ham.common.model.MediaListVO;
import jp.co.isid.ham.common.model.SecurityInfoVO;
import jp.co.isid.ham.common.model.Tbj01MediaPlanVO;
import jp.co.isid.ham.common.model.Tbj13CampDetailVO;
import jp.co.isid.ham.model.AbstractServiceResult;


/**
*
* <P>
* キャンペーン内容の情報を保持する.
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2012/12/05 FM h.izawa)<BR>
* </P>
* @author FM H.Izawa
*/
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindCampaignDetailsResult extends AbstractServiceResult {

    /** キャンペーン一覧の取得 */
    private List<FindCampaignDetailstVO> _rep;

    /** キャンペーン一覧の取得 */
    private List<Tbj13CampDetailVO> _rep1;

    /** 媒体状況管理データの取得 */
    private List<Tbj01MediaPlanVO> _mediaplan;

    /** 媒体マスタの取得 */
    private List<MediaListVO> _mediaList;

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
    public List<FindCampaignDetailstVO> getCampaignList() {
        return _rep;
    }

    /**

     * キャンペーン一覧VOリストを設定します
     * @param _cam セットする _cam
     */
    public void setCampaignList(List<FindCampaignDetailstVO> rep) {
        _rep = rep;
    }

    /**
     * キャンペーン一覧VOリストを取得します
     * @return _cam
     */
    public List<Tbj13CampDetailVO> getCampaignDetails() {
        return _rep1;
    }

    /**
     * キャンペーン一覧VOリストを設定します
     * @param _cam セットする _cam
     */
    public void setCampaignDetails(List<Tbj13CampDetailVO> rep1) {
        _rep1 = rep1;
    }

    /**
     * 媒体状況管理VOリストを取得します
     * @return _mediaplan
     */
    public List<Tbj01MediaPlanVO> getMediaPlan() {
        return _mediaplan;
    }

    /**
     * 媒体状況管理VOリストを設定します
     * @param _mediaplan セットする _mediaplan
     */
    public void setMediaPlan(List<Tbj01MediaPlanVO> mediaplan) {
        _mediaplan = mediaplan;
    }


    /**
     * キャンペーン一覧VOリストを取得します
     * @return _cam
     */
    public List<MediaListVO> getMediaList() {
        return _mediaList;
    }

    /**
     * キャンペーン一覧VOリストを設定します
     * @param _cam セットする _cam
     */
    public void setMediaList(List<MediaListVO> mediaList) {
        _mediaList = mediaList;
    }

    /**
     * スプレッドVOリストを取得します
     * @return _cam
     */
    public List<Mbj37DisplayControlVO> getSpdCont() {
        return _spdControl;
    }

    /**
     * スプレッドVOリストを設定します
     * @param _cam セットする _cam
     */
    public void setSpdCont(List<Mbj37DisplayControlVO> spdControl) {
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
