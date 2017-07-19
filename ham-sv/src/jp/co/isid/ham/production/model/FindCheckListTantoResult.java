package jp.co.isid.ham.production.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

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
public class FindCheckListTantoResult extends AbstractServiceResult {

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

    /** 発注局VOリスト */
    private List<FindCheckListHattyuKykVO> _findCheckListHattyuKykVoList = null;

    /**
     * 発注局VOリストを取得する
     *
     * @return 発注局VOリスト
     */
    public List<FindCheckListHattyuKykVO> getFindCheckListHattyuKykVoList() {
        return _findCheckListHattyuKykVoList;
    }

    /**
     * 発注局VOリストを設定する
     *
     * @param findCheckListHattyuKykVoList 発注局VOリスト
     */
    public void setFindCheckListHattyuKykVoList(List<FindCheckListHattyuKykVO> findCheckListHattyuKykVoList) {
        this._findCheckListHattyuKykVoList = findCheckListHattyuKykVoList;
    }

    /** 営業会計担当者VOリスト */
    private List<FindCheckListTantoVO> _findCheckListTantoVoList = null;

    /**
     * 営業会計担当者VOリストを取得する
     *
     * @return 営業会計担当者VOリスト
     */
    public List<FindCheckListTantoVO> getFindCheckListTantoVoList() {
        return _findCheckListTantoVoList;
    }

    /**
     * 営業会計担当者VOリストを設定する
     *
     * @param findCheckListTantoVoList 営業会計担当者VOリスト
     */
    public void setFindCheckListTantoVoList(List<FindCheckListTantoVO> findCheckListTantoVoList) {
        this._findCheckListTantoVoList = findCheckListTantoVoList;
    }


}
