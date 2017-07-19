package jp.co.isid.ham.media.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.CarListVO;
import jp.co.isid.ham.common.model.FunctionControlInfoVO;
import jp.co.isid.ham.common.model.Tbj02EigyoDaichoVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
*
* <P>
* 請求明細書出力画面情報を保持する.
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2012/12/20 HLC H.Watabe)<BR>
* </P>
* @author HLC H.Watabe
*/
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindBillStatementResult extends AbstractServiceResult{

    /** 車種の情報取得 */
    private List<CarListVO> _cl;

    /** 最終更新者情報の取得 */
    private List<Tbj02EigyoDaichoVO> _daicho;

    /** 機能制御Info */
    private List<FunctionControlInfoVO> _funcinfo;

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
     * 最終更新者情報を取得します
     * @return _daicho
     */
    public List<Tbj02EigyoDaichoVO> getTbj02EigyoDaicho() {
        return _daicho;
    }

    /**
     * 最終更新者情報を設定します
     * @param daicho
     */
    public void setTbj02EigyoDaicho(List<Tbj02EigyoDaichoVO> daicho) {
        _daicho = daicho;
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
