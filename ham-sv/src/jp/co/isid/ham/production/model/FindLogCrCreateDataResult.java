package jp.co.isid.ham.production.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * CR制作費更新履歴画面　実行時のデータ取得の結果クラス
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
public class FindLogCrCreateDataResult extends AbstractServiceResult {

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

    /** 更新履歴表示データログVOリスト */
    private List<FindLogCrCreateDataVO> _findLogCrCreateDataVoList = null;

    /**
     * 更新履歴表示データログVOリストを取得する
     *
     * @return 更新履歴表示データログVOリスト
     */
    public List<FindLogCrCreateDataVO> getFindLogCrCreateDataVoList() {
        return _findLogCrCreateDataVoList;
    }

    /**
     * CR車種情報VOリストを設定する
     *
     * @param tbj10CrCarInfoVoList CR車種情報VOリスト
     */
    public void setFindLogCrCreateDataVoList(List<FindLogCrCreateDataVO> findLogCrCreateDataVoList) {
        this._findLogCrCreateDataVoList = findLogCrCreateDataVoList;
    }


}
