package jp.co.isid.ham.media.model;

import java.util.List;
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

public class FindAccountBookLogResult extends AbstractServiceResult{

    /** 営業台帳ログ */
    private List<FindAccountBookLogVO> _log;

    /**
     * 営業台帳ログを取得する
     * @return 営業台帳ログ
     */
    public List<FindAccountBookLogVO> getLogAccountBook()
    {
        return _log;
    }

    /**
     * 営業台帳ログをセットする
     * @param list 営業台帳ログ
     */
    public void setLogAccountBook(List<FindAccountBookLogVO> list)
    {
        _log = list;
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
