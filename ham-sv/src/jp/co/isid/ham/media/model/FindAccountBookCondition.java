package jp.co.isid.ham.media.model;

import java.io.Serializable;
import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 営業作業台帳検索クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/07/16 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindAccountBookCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;


    /** 媒体管理No */
    private List<String> _mediaPlanNo = null;

    /** ダミー */
    private String _dummy = null;


    /**
     * 媒体管理Noを取得する
     *
     * @return 媒体管理No
     */
    public List<String> getMediaPlanNo() {
        return _mediaPlanNo;
    }

    /**
     * 媒体管理Noを設定する
     *
     * @param mediaPnalNo 媒体管理No
     */
    public void setMediaPlanNo(List<String> mediaPlanlNo) {
        _mediaPlanNo = mediaPlanlNo;
    }

    /**
     * ダミーを取得する
     *
     * @return ダミー
     */
    public String getDummy()
    {
        return _dummy;
    }

    /**
     * ダミーを設定する
     *
     * @param dummy ダミー
     */
    public void setDummy(String dummy)
    {
        _dummy = dummy;
    }

}
