package jp.co.isid.ham.production.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * 契約情報登録画面削除ボタン押下時データ取得の結果クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(20ム
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class ContractDeleteResult extends AbstractServiceResult{

    /* =============================================================================================*/
    /** ListだけではWebサービスに公開されないのでダミープロパティを追加 */
    private String _dummy;

    /**
     * ListだけではWebサービスに公開されないのでダミープロパティを取得します
     * @return String ダミープロパティ
     */
    public String getDummy() {
        return _dummy;
    }

    /**
     * ListだけではWebサービスに公開されないのでダミープロパティを設定します
     * @param dummy ダミープロパティ
     */
    public void setDummy(String dummy) {
        this._dummy = dummy;
    }
    /* =============================================================================================*/
    /** 削除ボタン押下時のコンテンツカウント取得VOリスト */
    private List<ContractDeleteCVO> _contractDeleteCVOList = null;

    /** 削除ボタン押下時のJASRACカウント取得VOリスト */
    private List<ContractDeleteJVO> _contractDeleteJVOList = null;

    /**
     * コンテンツカウントVOリストを取得する
     * @return コードマスタVOリスト
     */
    public List<ContractDeleteCVO> getContractDeleteCVOList() {
        return _contractDeleteCVOList;
    }

    /**
     * コンテンツカウントVOリストを設定する
     * @param mbj12CodeVOList コードマスタVOリスト
     */
    public void setContractDeleteCVOList(List<ContractDeleteCVO> contractDeleteCVOList) {
        this._contractDeleteCVOList = contractDeleteCVOList;
    }

    /**
     * JASRACカウントVOリストを取得する
     * @return コードマスタVOリスト
     */
    public List<ContractDeleteJVO> getContractDeleteJVOList() {
        return _contractDeleteJVOList;
    }

    /**
     * JASRACカウントVOリストを設定する
     * @param mbj12CodeVOList コードマスタVOリスト
     */
    public void setContractDeleteJVOList(List<ContractDeleteJVO> contractDeleteJVOList) {
        this._contractDeleteJVOList = contractDeleteJVOList;
    }

}
