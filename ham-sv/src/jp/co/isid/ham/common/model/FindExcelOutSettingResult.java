package jp.co.isid.ham.common.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
*
* <P>
* 帳票出力設定の情報を保持する.
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2013/01/09 HLC H.Watabe)<BR>
* </P>
* @author HLC H.Watabe
*/
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindExcelOutSettingResult extends AbstractServiceResult{

    /** 出力媒体の情報取得 */
    private List<OutputMediaVO> _om;

    /** 出力車種の情報取得 */
    private List<OutputCarVO> _oc;

    /** 出力しない媒体の情報取得 */
    private List<Mbj03MediaVO> _media;

    /** 出力しない車種の情報取得 */
    private List<Mbj05CarVO> _car;

    /**
     * 出力媒体VOを取得します
     * @return _om
     */
    public List<OutputMediaVO> getOutputMedia() {
        return _om;
    }

    /**
     * 出力媒体VOを設定します
     * @param _om セットする _om
     */
    public void setOutputMedia(List<OutputMediaVO> om) {
        _om = om;
    }

    /**
     * 出力媒体VOを取得します
     * @return _om
     */
    public List<OutputCarVO> getOutputCar() {
        return _oc;
    }

    /**
     * 出力媒体VOを設定します
     * @param _om セットする _om
     */
    public void setOutputCar(List<OutputCarVO> oc) {
        _oc = oc;
    }

    /**
     * 出力しない媒体VOを取得します
     * @return
     */
    public List<Mbj03MediaVO> getMbj03Media() {
        return _media;
    }

    /**
     * 出力しない媒体VOを設定します
     * @param media セットする _media
     */
    public void setMbj03Media(List<Mbj03MediaVO> media) {
        _media = media;
    }

    /**
     * 出力しない車種VOを取得します
     * @return
     */
    public List<Mbj05CarVO> getMbj05Car() {
        return _car;
    }

    /**
     * 出力しない車種VOを設定します
     * @param car
     */
    public void setMbj05Car(List<Mbj05CarVO> car) {
        _car = car;
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
