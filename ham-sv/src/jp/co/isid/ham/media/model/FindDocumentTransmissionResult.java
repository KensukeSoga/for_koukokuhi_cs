package jp.co.isid.ham.media.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.FunctionControlInfoVO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
* <P>
* 送稿表画面の情報を保持する.
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2013/09/20 Fujiyoshi)<BR>
* </P>
* @author Fujiyoshi
*/
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindDocumentTransmissionResult extends AbstractServiceResult {

    /** 送稿表画面表示データ */
    private List<FindDocumentTransmissionVO> _fdtvo;

    /** 画面項目表示列制御マスタ */
    private List<Mbj37DisplayControlVO> _dc;

    /** 機能制御Info */
    private List<FunctionControlInfoVO> _funcinfo;


    /**
     * 送稿表画面表示データを取得する
     * @return 送稿表画面表示データ
     */
    public List<FindDocumentTransmissionVO> getFindDocumentTransmission() {
        return _fdtvo;
    }

    /**
     * 送稿表画面表示データを設定する
     * @param fdtvo 送稿表画面表示データ
     */
    public void setFindDocumentTransmission(List<FindDocumentTransmissionVO> fdtvo) {
        _fdtvo = fdtvo;
    }

    /**
     * 画面項目表示列制御マスタを取得する
     *
     * @return 画面項目表示列制御マスタ
     */
    public List<Mbj37DisplayControlVO> getDisplayControl() {
        return _dc;
    }

    /**
     * 画面項目表示列制御マスタを設定する
     *
     * @param dc 画面項目表示列制御マスタ
     */
    public void setDisplayControl(List<Mbj37DisplayControlVO> dc) {
        _dc = dc;
    }

    /**
     * 機能制御InfoVOリストを取得する
     * @return 機能制御InfoVOリスト
     */
    public List<FunctionControlInfoVO> getFunctionControlInfoVoList() {
        return _funcinfo;
    }

    /**
     * 機能制御InfoVOリストを設定する
     * @param secinfo 機能制御InfoVOリスト
     */
    public void setFunctionControlInfoVoList(List<FunctionControlInfoVO> funcinfo) {
        _funcinfo = funcinfo;
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
