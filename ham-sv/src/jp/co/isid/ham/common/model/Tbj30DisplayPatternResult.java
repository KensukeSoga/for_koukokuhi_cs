package jp.co.isid.ham.common.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * 一覧表示パターンを保持する
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/11 K.Fukuda)<BR>
 * </P>
 * @author K.Fukuda
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj30DisplayPatternResult extends AbstractServiceResult{

    /**
     * 一覧表示パターンVOリスト
     */
    private Tbj30DisplayPatternVO _dp;

    /**
     * 一覧表示パターンVOリストを取得します
     * @return  一覧表示パターンVOリスト
     */
    public Tbj30DisplayPatternVO getDisplayPattern() {
        return _dp;
    }

    /**
     * 一覧表示パターンVOリストを設定します
     * @param dc  一覧表示パターンVOリスト
     */
    public void setDisplayControlList(Tbj30DisplayPatternVO dp) {
        _dp = dp;
    }

}
