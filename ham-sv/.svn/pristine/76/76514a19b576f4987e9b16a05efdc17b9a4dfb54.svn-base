package jp.co.isid.ham.production.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * CR制作費　変更内容通知検索実行時のデータ取得の結果クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/06/24 新HAMチーム)<BR>
 * </P>
 *
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class FindChangeNoticeResult extends AbstractServiceResult {

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

    /** 変更内容データVOリスト */
    private List<FindChangeNoticeVO> _FindChangeNoticeVoList = null;

    /**
     * 変更内容データVOリストを取得する
     *
     * @return 変更内容データVOリスト
     */
    public List<FindChangeNoticeVO> getFindChangeNoticeVoList() {
        return _FindChangeNoticeVoList;
    }

    /**
     * 変更内容データVOリストを設定する
     *
     * @param FindChangeNoticeVoList 変更内容データVOリスト
     */
    public void setFindChangeNoticeVoList(List<FindChangeNoticeVO> FindChangeNoticeVoList) {
        this._FindChangeNoticeVoList = FindChangeNoticeVoList;
    }


}
