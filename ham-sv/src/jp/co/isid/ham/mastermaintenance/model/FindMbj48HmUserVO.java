package jp.co.isid.ham.mastermaintenance.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;
import jp.co.isid.ham.common.model.Mbj48HmUserVO;

/**
 * <P>
 * HM担当者検索データVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMbj48HmUserVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** データVOリスト */
    private List<Mbj48HmUserVO> _findList;

    /**
     * デフォルトコンストラクタ
     */
    public FindMbj48HmUserVO()
    {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new FindMbj48HmUserVO();
    }

    /**
     * データVOリストを設定する
     * @param voList List<Mbj48HmUserVO> データVOリスト
     */
    public void setFindList(List<Mbj48HmUserVO> voList) {
        _findList = voList;
    }

    /**
     * データVOリストを取得する
     * @return List<Mbj48HmUserVO> データVOリスト
     */
    public List<Mbj48HmUserVO> getFindList() {
        return _findList;
    }

    /** ListだけではWebサービスに公開されないのでダミープロパティを追加 */
    private String _dummy;

    /**
     * ListだけではWebサービスに公開されないのでダミープロパティを追加を設定する
     * @param dummy ダミープロパティ
     */
    public void setDummy(String dummy) {
        _dummy = dummy;
    }

    /**
     * ListだけではWebサービスに公開されないのでダミープロパティを追加を取得する
     * @return String ダミープロパティ
     */
    public String getDummy() {
        return _dummy;
    }

}
