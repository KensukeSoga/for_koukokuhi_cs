package jp.co.isid.ham.media.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj12CodeVO;
import jp.co.isid.ham.common.model.RepaVbjaMeu14ThsTntTrVO;
import jp.co.isid.ham.common.model.RepaVbjaMeu20MsMzBtVO;
import jp.co.isid.ham.common.model.RepaVbjaMeu29CcVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
* <P>
* DKB連携ファイル出力用の情報を保持する.
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2013/02/19 HLC H.Watabe)<BR>
* </P>
* @author HLC H.Watabe
*/
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindCooperationDataResult extends AbstractServiceResult {

    /** 組織データVO */
    private List<FindSocietyDataVO> _societyVO;

    /** 取引担当VO */
    private List<RepaVbjaMeu14ThsTntTrVO> _charge;

    /** 新雑媒体VO */
    private List<RepaVbjaMeu20MsMzBtVO> _mediaVO;

    /** コードマスタVO */
    private List<RepaVbjaMeu29CcVO> _codeMasterVO;

    /** コードマスタVO(HAM) */
    private List<Mbj12CodeVO> _codeVO;

    /** 費目VO */
    private List<FindItemVO> _itemVO;

    /** 値引き区分VO */
    private List<FindDiscountFlgVO> _discFlgVO;

    /** スペース(スペースのカラムに入力可能な値とそのコード) */
    private List<RepaVbjaMeu29CcVO> _space;


    /**
     * 組織データ取得
     * @return
     */
    public List<FindSocietyDataVO> getSocietyData() {
        return _societyVO;
    }

    /**
     * 組織データ設定
     * @param societyVO
     */
    public void setSocietyData(List<FindSocietyDataVO> societyVO) {
        this._societyVO = societyVO;
    }

    /**
     * 取引担当取得
     * @return
     */
    public List<RepaVbjaMeu14ThsTntTrVO> getRepaVbjaMeu14ThsTntTr() {
        return _charge;
    }

    /**
     * 取引担当設定
     * @param charge
     */
    public void setRepaVbjaMeu14ThsTntTr(List<RepaVbjaMeu14ThsTntTrVO> charge) {
        this._charge = charge;
    }

    /**
     * 新雑媒体取得
     * @return
     */
    public List<RepaVbjaMeu20MsMzBtVO> getRepaVbjaMeu20MsMzBtVO() {
        return _mediaVO;
    }

    /**
     * 新雑媒体設定
     * @param mediaVO
     */
    public void setRepaVbjaMeu20MsMzBtVO(List<RepaVbjaMeu20MsMzBtVO> mediaVO) {
        this._mediaVO = mediaVO;
    }

    /**
     * コードマスタ取得
     * @return
     */
    public List<RepaVbjaMeu29CcVO> getRepaVbjaMeu29CcVO() {
        return _codeMasterVO;
    }

    /**
     * コードマスタ設定
     * @param codeMasterVO
     */
    public void setRepaVbjaMeu29CcVO(List<RepaVbjaMeu29CcVO> codeMasterVO) {
        this._codeMasterVO = codeMasterVO;
    }

    /**
     * コードマスタ(HAM)取得
     * @return
     */
    public List<Mbj12CodeVO> getMbj12Code() {
        return _codeVO;
    }

    /**
     * コードマスタ(HAM)設定
     * @param codeVO
     */
    public void setMbj12Code(List<Mbj12CodeVO> codeVO) {
        this._codeVO = codeVO;
    }

    /**
     * 費目取得
     * @return
     */
    public List<FindItemVO> getItem() {
        return _itemVO;
    }

    /**
     * 費目設定
     * @param itemVO
     */
    public void setItem(List<FindItemVO> itemVO) {
        this._itemVO = itemVO;
    }

    /**
     * 値引き区分取得
     * @return
     */
    public List<FindDiscountFlgVO> getDiscountFlg() {
        return _discFlgVO;
    }

    /**
     * 値引き区分設定
     * @param discFlg
     */
    public void setDiscountFlg(List<FindDiscountFlgVO> discFlg) {
        this._discFlgVO = discFlg;
    }

    /**
     * スペース取得
     * @return スペース
     */
    public List<RepaVbjaMeu29CcVO> getSpace() {
        return _space;
    }

    /**
     * スペース設定
     * @param space スペース
     */
    public void setSpace(List<RepaVbjaMeu29CcVO> space) {
        _space = space;
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
