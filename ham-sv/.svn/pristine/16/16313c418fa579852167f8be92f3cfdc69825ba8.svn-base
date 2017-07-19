package jp.co.isid.ham.mastermaintenance.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

import jp.co.isid.ham.common.model.Mbj09HiyouVO;

/**
 * <P>
 * 費用企画No検索データVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/11 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMbj09HiyouVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** データVOリスト */
    private List<Mbj09HiyouVO> _findList;

    /**
     * デフォルトコンストラクタ
     */
    public FindMbj09HiyouVO()
    {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance()
    {
        return new FindMbj09HiyouVO();
    }

    /**
     * データVOリストを設定します
     * @param voList セットする _findList
     */
    public void setFindList(List<Mbj09HiyouVO> voList)
    {
        _findList = voList;
    }

    /**
     * データVOリストを取得します
     * @return _findList
     */
    public List<Mbj09HiyouVO> getFindList()
    {
        return _findList;
    }

    /** ListだけではWebサービスに公開されないのでダミープロパティを追加 */
    private String _dummy;

    /**
     * ListだけではWebサービスに公開されないのでダミープロパティを追加を設定します
     * @param dummy ダミープロパティ
     */
    public void setDummy(String dummy)
    {
        _dummy = dummy;
    }

    /**
     * ListだけではWebサービスに公開されないのでダミープロパティを追加を取得します
     * @return String ダミープロパティ
     */
    public String getDummy()
    {
        return _dummy;
    }

}
