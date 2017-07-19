package jp.co.isid.ham.common.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * コードマスタを保持する
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/6 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj12CodeResult extends AbstractServiceResult {

    /**
     * コードマスタVOリスト
     */
    private List<Mbj12CodeVO> _dc;

    /**
     * コードマスタVOリストを取得します
     * @return  コードマスタVOリスト
     */
    public List<Mbj12CodeVO> getCodeList() {
        return _dc;
    }

    /**
     * コードマスタVOリストを設定します
     * @param dc  コードマスタVOリスト
     */
    public void setCodeList(List<Mbj12CodeVO> dc) {
        _dc = dc;
    }

}
