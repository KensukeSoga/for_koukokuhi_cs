package jp.co.isid.ham.media.model;

import java.util.List;
import jp.co.isid.ham.common.model.*;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
*
* <P>
* 営業作業台帳の情報を保持する.
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2012/12/03 HLC H.Watabe)<BR>
* </P>
* @author HLC H.Watabe
*/
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")

public class FindAuthorityAccountBookResult extends AbstractServiceResult {

    /** 営業作業台帳の情報取得 */
    private List<FindAuthorityAccountBookVO> _abo;

    /** 媒体状況管理の情報取得 */
    private List<Tbj01MediaPlanVO> _mp;

    /** キャンペーンの情報取得 */
    private List<Tbj12CampaignVO> _cp;

    /** 媒体種別の取得 */
    private List<FindMediaCategoryVO> _mct;

    /** キャンペーン名の取得 */
    private List<FindAccountBookCampaignVO> _abcam;

    /** 内容費目の情報取得 */
    private List<FindExpenseItemListVO> _ei;

    /** スペースの情報取得 */
    private List<FindSpaceVO> _space;

    /** 画面項目表示列制御マスタ */
    private List<Mbj37DisplayControlVO> _dc;

    /** 一覧表示パターン */
    private List<Tbj30DisplayPatternVO> _dp;

    /** 車種の情報取得 */
    private List<CarListVO> _cl;

    /** 媒体の情報取得 */
    private List<MediaListVO> _ml;

    /** 全社マスタのコードマスタ */
    private List<RepaVbjaMeu29CcVO> _mc;

    /** 依頼先情報 */
    private List<RepaVbjaMea10IrskVO> _od;

    /** 依頼先 */
    private List<FindContactRequestVO> _fcr;

    /** コードマスタ */
    private List<Mbj12CodeVO> _cd;

    /** セキュリティInfo */
    private List<SecurityInfoVO> _secinfo;

    /** 機能制御Info */
    private List<FunctionControlInfoVO> _funcinfo;

    /** スペースマスタ値 */
    private List<RepaVbjaMeu29CcVO> _spaceMaster;

    /** 新聞マスタ */
    private List<Mbj47NewspaperVO> _newspaper;

    /** 依頼先絞り込み情報 */
    private List<FindContactRequestNarrowingVO> _fcrn;


    /**
     * 営業作業台帳VOを取得します
     * @return _abo
     */
    public List<FindAuthorityAccountBookVO> getAuthorityAccountBook() {
        return _abo;
    }

    /**
     * 営業作業台帳VOを設定します
     * @param _cam セットする _cam
     */
    public void setAuthorityAccountBook(List<FindAuthorityAccountBookVO> abo) {
        _abo = abo;
    }

    /**
     * 媒体状況管理VOを取得
     * @return 媒体状況管理
     */
    public List<Tbj01MediaPlanVO> getTbj01MediaPlan() {
        return _mp;
    }

    /**
     * 媒体状況管理VOを設定
     * @param mp
     */
    public void setTbj01MediaPlan(List<Tbj01MediaPlanVO> mp) {
        _mp = mp;
    }

    /**
     * キャンペーンVOを取得
     * @return キャンペーン
     */
    public List<Tbj12CampaignVO> getTbj12Campaign() {
        return _cp;
    }

    /**
     * キャンペーンVOを設定
     * @param cp
     */
    public void setTbj12Campaign(List<Tbj12CampaignVO> cp) {
        _cp = cp;
    }

    /**
     * 媒体種別VOを取得します
     * @return _mct
     */
    public List<FindMediaCategoryVO> getMediaCategory() {
        return _mct;
    }

    /**
     * 媒体種別VOを設定します
     * @param _mct セットする _mct
     */
    public void setMediaCategory(List<FindMediaCategoryVO> mct) {
        _mct = mct;
    }

    /**
     * キャンペーンVOの取得
     *
     * @return _abcam
     */
    public List<FindAccountBookCampaignVO> getAccountBookCampaign()
    {
        return _abcam;
    }

    /**
     * キャンペーンVOの設定
     * @param abcam セットする _abcam
     */
    public void setAccountBookCampaign(List<FindAccountBookCampaignVO> abcam)
    {
        _abcam = abcam;
    }

    /**
     * 内容費目VOの取得
     *
     * @return _abcam
     */
    public List<FindExpenseItemListVO> getExpenseItemList()
    {
        return _ei;
    }

    /**
     * 内容費目VOの設定
     * @param abcam セットする _abcam
     */
    public void setExpenseItemList(List<FindExpenseItemListVO> ei)
    {
        _ei = ei;
    }

    /**
     * スペースを取得
     * @return スペース
     */
    public List<FindSpaceVO> getSpace() {
        return _space;
    }

    /**
     * スペースを設定
     * @param space
     */
    public void setSpace(List<FindSpaceVO> space) {
        _space = space;
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
     * 一覧表示パターンを取得する
     *
     * @return 一覧表示パターン
     */
    public List<Tbj30DisplayPatternVO> getDisplayPattern() {
        return _dp;
    }

    /**
     * 一覧表示パターンを設定する
     *
     * @param dp 一覧表示パターン
     */
    public void setDisplayPattern(List<Tbj30DisplayPatternVO> dp) {
        _dp = dp;
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
     * @param dc 車種一覧
     */
    public void setCarList(List<CarListVO> cl) {
        _cl = cl;
    }

    /**
     * 媒体一覧を取得する
     * @return 媒体一覧
     */
    public List<MediaListVO> getMediaList() {
        return _ml;
    }

    /**
     * 媒体一覧を設定する
     * @param ml 媒体一覧
     */
    public void setMediaList(List<MediaListVO> ml) {
        _ml = ml;
    }

    /**
     * 依頼先情報を取得する
     * @return 依頼先情報
     */
    public List<RepaVbjaMea10IrskVO> getRepaVbjaMea10Irsk() {
        return _od;
    }

    /**
     * 依頼先情報を設定する
     * @param od 依頼先情報
     */
    public void setRepaVbjaMea10Irsk(List<RepaVbjaMea10IrskVO> od) {
        _od = od;
    }

    /**
     * 依頼先を取得する
     * @return 依頼先
     */
    public List<FindContactRequestVO> getFindContactRequest() {
        return _fcr;
    }

    /**
     * 依頼先を設定する
     * @param fcr 依頼先
     */
    public void setFindContactRequest(List<FindContactRequestVO> fcr) {
        _fcr = fcr;
    }

    /**
     * 全社マスタのコードマスタを取得する
     * @return 全社マスタのコードマスタ
     */
    public List<RepaVbjaMeu29CcVO> getRepaVbjaMeu29Cc() {
        return _mc;
    }

    /**
     * 全社マスタのコードマスタを設定する
     * @param mc 全社マスタのコードマスタ
     */
    public void setRepaVbjaMeu29Cc(List<RepaVbjaMeu29CcVO> mc) {
        _mc = mc;
    }

    /**
     * コードマスタを取得する
     * @return コードマスタ
     */
    public List<Mbj12CodeVO> getMbj12Code() {
        return _cd;
    }

    /**
     * コードマスタを設定する
     * @param cd コードマスタ
     */
    public void setMbj12Code(List<Mbj12CodeVO> cd) {
        _cd = cd;
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

    /**
     * スペースマスタVOリストを取得する
     * @return スペースマスタVOリスト
     */
    public List<RepaVbjaMeu29CcVO>  getSpaceMasterList() {
        return _spaceMaster;
    }

    /**
     * スペースマスタVOリストを設定する
     * @param spaceMaster スペースマスタVOリスト
     */
    public void setSpaceMasterList(List<RepaVbjaMeu29CcVO> spaceMaster) {
        _spaceMaster = spaceMaster;
    }

    /**
     * 新聞マスタVOリストを取得する
     * @return 新聞マスタVOリスト
     */
    public List<Mbj47NewspaperVO> getNewspaper() {
        return _newspaper;
    }

    /**
     * 新聞マスタVOリストを設定する
     * @param newspaper 新聞マスタVOリスト
     */
    public void setNewspaper(List<Mbj47NewspaperVO> newspaper) {
        _newspaper = newspaper;
    }

    /**
     * 依頼先絞り込み情報を取得する
     * @return 依頼先絞り込み情報
     */
    public List<FindContactRequestNarrowingVO> getFCRNarrowing() {
        return _fcrn;
    }

    /**
     * 依頼先絞り込み情報を設定する
     * @param fcrn 依頼先絞り込み情報
     */
    public void setFCRNarrowing(List<FindContactRequestNarrowingVO> fcrn) {
        _fcrn = fcrn;
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
