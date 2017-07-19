package jp.co.isid.ham.production.model;

import java.io.Serializable;
import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 契約情報登録　検索実行時のデータ取得条件クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/02/15 新HAMチーム)<BR>
 * </P>
 *
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class FindLogContractInfoCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 担当者ID */
    private String _hamid = null;

    /** 履歴キー */
    private BigDecimal _historykey = null;

    /**
     * 担当者IDを取得する
     *
     * @return 担当者ID
     */
    public String getHamid() {
        return _hamid;
    }

    /**
     * 担当者IDを設定する
     *
     * @param hamid 担当者ID
     */
    public void setHamid(String hamid) {
        this._hamid = hamid;
    }

    /**
     * 履歴キーを取得する
     *
     * @return 履歴キー
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getHistorykey() {
        return _historykey;
    }

    /**
     * 履歴キーを設定する
     *
     * @param historykey 履歴キー
     */
    public void setHistorykey(BigDecimal historykey) {
        this._historykey = historykey;
    }
}
