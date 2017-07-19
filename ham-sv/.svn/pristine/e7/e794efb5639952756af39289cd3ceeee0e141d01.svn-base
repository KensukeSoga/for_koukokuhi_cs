package jp.co.isid.ham.production.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Vbj01AccUserVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * メールアドレス検索実行時のデータ取得の結果クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/06/28 新HAMチーム)<BR>
 * </P>
 *
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class FindMailInfoResult extends AbstractServiceResult {

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

    /**
     * 新HAM向けVIEW(個人情報)VOリスト
     */
    private List<Vbj01AccUserVO> _accUserVoList;

    /**
     * 新HAM向けVIEW(個人情報)VOリストを取得します
     * @return 新HAM向けVIEW(個人情報)
     */
    public List<Vbj01AccUserVO> getAccUserList() {
        return _accUserVoList;
    }

    /**
     * 新HAM向けVIEW(個人情報)VOリストを設定します
     * @param vbj01vo 新HAM向けVIEW(個人情報)
     */
    public void setAccUserList(List<Vbj01AccUserVO> accUserVoList) {
        _accUserVoList = accUserVoList;
    }

}
