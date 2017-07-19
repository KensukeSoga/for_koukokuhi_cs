package jp.co.isid.ham.media.model;

import java.util.List;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.common.model.MediaListVO;
import jp.co.isid.ham.common.model.Tbj01MediaPlanVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
*
* <P>
* 媒体状況管理の情報を保持する.
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2012/12/17 FM h.izawa)<BR>
* </P>
* @author FM H.Izawa
*/
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindSumCarResult extends AbstractServiceResult {

    /**媒体状況管理の金額合計を取得*/
    private List<Tbj01MediaPlanVO> _rep;

    /**媒体名称を取得します*/
    private List<MediaListVO> _rep1;

    /** ListだけではWebサービスに公開されないのでダミープロパティを追加 */
    private String _dummy;

    /**
     * 媒体状況管理データを取得します.
     * @return 媒体状況の金額合計
     */
    public List<Tbj01MediaPlanVO> getCarSum() {
        return _rep;
    }

    /**
     * 媒体状況管理データの設定を行います.
     * @param 媒体状況の金額合計
     */
    public void setCarSum(List<Tbj01MediaPlanVO> rep) {
        this._rep = rep;
    }

    /**
     * 媒体名の取得をします
     * @return 媒体名
     */
    public List<MediaListVO> getMedia() {
        return _rep1;
    }

    /**
     * 媒体名の設定を行います.
     * @param 媒体名
     */
    public void setMedia(List<MediaListVO> rep1) {
        this._rep1 = rep1;
    }



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
