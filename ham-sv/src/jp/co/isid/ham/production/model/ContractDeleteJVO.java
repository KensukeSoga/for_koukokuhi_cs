package jp.co.isid.ham.production.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 削除ボタン押下時のJASRACカウント取得VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/14 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class ContractDeleteJVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

//    /**
//     * 契約コード
//     */
//    private String _CTRTNO = null;

    /**
     * カウント
     */
    private int _COUNT = 0;

    /**
     * デフォルトコンストラクタ
     */
    public ContractDeleteJVO() {
        //スーパークラスのコンストラクタを呼び出す
        super();
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new ContractDeleteJVO();
    }

//    /**
//     * 契約コードを取得する
//     *
//     * @return 契約コード
//     */
//    public String getCTRTNO() {
//        return _CTRTNO;
//    }
//
//    /**
//     * 契約コードを設定する
//     *
//     * @param val 契約コード
//     */
//    public void setCTRTNO(String val) {
//        _CTRTNO = val;
//    }

    /**
     * カウントを取得する
     *
     * @return カウント
     */
    public int getCOUNT() {
        return _COUNT;
    }

    /**
     * カウントを設定する
     *
     * @param val カウント
     */
    public void setCOUNT(int val) {
        _COUNT = val;
    }

}
