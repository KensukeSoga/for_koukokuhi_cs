package jp.co.isid.ham.media.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Tbj01MediaPlanVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
* <P>
* TVTimeインポートに必要な情報を保持する.
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2013/01/22 HLC H.Watabe)<BR>
* </P>
* @author HLC H.Watabe
*/
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindTimeExcelImportResult extends AbstractServiceResult {

    /** 媒体状況管理の情報取得 */
    private List<Tbj01MediaPlanVO> _mpVO;

    /** 営業作業台帳の情報取得 */
    private List<FindAuthorityAccountBookVO> _acVO;

    /**
     * 媒体状況管理VOを取得
     * @return 媒体状況管理VO
     */
    public List<Tbj01MediaPlanVO> getMediaPlan() {
        return _mpVO;
    }

    /**
     * 媒体状況管理VOを設定
     * @param mpVO セットする媒体状況管理VO
     */
    public void setMediaPlan(List<Tbj01MediaPlanVO> mpVO) {
        this._mpVO = mpVO;
    }

    /**
     * 営業作業台帳VOを取得
     * @return 営業作業台帳VO
     */
    public List<FindAuthorityAccountBookVO> getAccountBook() {
        return _acVO;
    }

    /**
     * 営業作業台帳VOを設定
     * @param acVO セットする営業作業台帳VO
     */
    public void setAccountBook(List<FindAuthorityAccountBookVO> acVO) {
        this._acVO = acVO;
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
