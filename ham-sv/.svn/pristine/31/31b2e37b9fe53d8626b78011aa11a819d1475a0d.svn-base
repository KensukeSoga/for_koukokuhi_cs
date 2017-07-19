package jp.co.isid.ham.media.model;

import java.util.List;
import jp.co.isid.ham.common.model.*;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
*
* <P>
* 営業作業台帳帳票出力画面情報を保持する.
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2012/12/20 HLC H.Watabe)<BR>
* </P>
* @author HLC H.Watabe
*/
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindAccountBookOutputResult extends AbstractServiceResult{

    /** 車種の情報取得 */
    private List<CarListVO> _cl;

    /** 媒体の情報取得 */
    private List<MediaListVO> _ml;

//    /** 営業作業台帳帳票の情報取得 */
//    private List<FindAuthorityAccountBookReportVO> _aborep;

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

//    /**
//     * 営業作業台帳帳票VOを取得します
//     * @return _aborep
//     */
//    public List<FindAuthorityAccountBookReportVO> getAuthorityAccountBookReport() {
//        return _aborep;
//    }
//
//    /**
//     * 営業作業台帳帳票VOを設定します
//     * @param _adorep セットする
//     */
//    public void setAuthorityAccountBookReport(List<FindAuthorityAccountBookReportVO> aborep) {
//        _aborep = aborep;
//    }


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
