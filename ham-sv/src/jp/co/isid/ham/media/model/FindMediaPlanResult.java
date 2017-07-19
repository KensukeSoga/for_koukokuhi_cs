package jp.co.isid.ham.media.model;

import java.util.List;
import jp.co.isid.ham.common.model.*;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
*
* <P>
* 媒体状況管理の情報を保持する.
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2013/01/18 HLC M.Tsuchiya)<BR>
* </P>
* @author HLC M.Tsuchiya
*/
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")

public class FindMediaPlanResult extends AbstractServiceResult {

    /** 媒体状況管理の情報取得 */
    private List<FindMediaPlanVO> _mp;

    /** 車種リスト(権限つき)の情報取得 */
    private List<CarListVO> _cl;

    /** キャンペーンNoの取得 */
    private List<FindMediaPlanCampaignVO> _mpcam;

    /** 媒体の情報取得 */
    private List<MediaListVO> _ml;

    /** 画面項目表示列制御マスタ */
    private List<Mbj37DisplayControlVO> _dc;

    /** セキュリティInfo */
    private List<SecurityInfoVO> _secinfo;

    /** 機能制御Info */
    private List<FunctionControlInfoVO> _funcinfo;

    /**
     * 媒体状況管理VOを取得します
     * @return _mp
     */
    public List<FindMediaPlanVO> getMediaPlan() {
        return _mp;
    }

    /**
     * 媒体状況管理VOを設定します
     * @param _mp セットする _mp
     */
    public void setMediaPlan(List<FindMediaPlanVO> mp) {
        _mp = mp;
    }

    /**
     * 車種一覧を取得する
     *
     * @return 車種一覧
     */
    public List<CarListVO> getCarList() {
        return _cl;
    }

    /**
     * 車種一覧を設定する
     *
     * @param cl 車種一覧
     */
    public void setCarList(List<CarListVO> cl) {
        _cl = cl;
    }

    /**
     * キャンペーンNoを取得する
     *
     * @return キャンペーンNo
     */
    public List<FindMediaPlanCampaignVO> getMediaPlanCampaign() {
        return _mpcam;
    }

    /**
     * キャンペーンNoを設定する
     *
     * @param cl キャンペーンNo
     */
    public void setMediaPlanCampaign(List<FindMediaPlanCampaignVO> mpcam) {
        _mpcam = mpcam;
    }

    /**
     * 媒体を取得する
     *
     * @return 媒体
     */
    public List<MediaListVO> getMediaList() {
        return _ml;
    }

    /**
     * 媒体を設定する
     *
     * @param ml 媒体
     */
    public void setMediaList(List<MediaListVO> ml) {
        _ml = ml;
    }

    /**
     * 画面項目表示列制御マスタを取得する
     *
     * @return 画面項目表示列制御マスタ
     */
    public List<Mbj37DisplayControlVO> getDisplayControl() {
        return _dc;
    }

    /**
     * 画面項目表示列制御マスタを設定する
     *
     * @param dc 画面項目表示列制御マスタ
     */
    public void setDisplayControl(List<Mbj37DisplayControlVO> dc) {
        _dc = dc;
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
