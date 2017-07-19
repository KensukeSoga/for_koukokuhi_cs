package jp.co.isid.ham.mastermaintenance.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

import jp.co.isid.ham.common.model.RegistExclusionVO;
import jp.co.isid.ham.common.model.Mbj01SysStsVO;

/**
 * <P>
 * 過去ロック登録データVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/04 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class RegistMbj01SysStsVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 排他ロック情報VO */
    RegistExclusionVO _exclusion;

    /** データVO挿入リスト */
    private List<Mbj01SysStsVO> _insertList;

    /** データVO更新リスト */
    private List<Mbj01SysStsVO> _updateList;

    /** データVO削除リスト */
    private List<Mbj01SysStsVO> _deleteList;

    /**
     * デフォルトコンストラクタ
     */
    public RegistMbj01SysStsVO()
    {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance()
    {
        return new RegistMbj01SysStsVO();
    }

    /**
     * 排他ロック情報VOを設定します
     * @param vo セットする _exclusion
     */
    public void setExclusion(RegistExclusionVO vo)
    {
        _exclusion = vo;
    }

    /**
     * 排他ロック情報VOを取得します
     * @return _exclusion
     */
    public RegistExclusionVO getExclusion()
    {
        return _exclusion;
    }

    /**
     * データVO挿入リストを設定します
     * @param voList セットする _insertList
     */
    public void setInsertList(List<Mbj01SysStsVO> voList)
    {
        _insertList = voList;
    }

    /**
     * データVO挿入リストを取得します
     * @return _insertList
     */
    public List<Mbj01SysStsVO> getInsertList()
    {
        return _insertList;
    }

    /**
     * データVO更新リストを設定します
     * @param voList セットする _updateList
     */
    public void setUpdateList(List<Mbj01SysStsVO> voList)
    {
        _updateList = voList;
    }

    /**
     * データVO更新リストを取得します
     * @return _updateList
     */
    public List<Mbj01SysStsVO> getUpdateList()
    {
        return _updateList;
    }

    /**
     * データVO削除リストを設定します
     * @param voList セットする _deleteList
     */
    public void setDeleteList(List<Mbj01SysStsVO> voList)
    {
        _deleteList = voList;
    }

    /**
     * データVO削除リストを取得します
     * @return _deleteList
     */
    public List<Mbj01SysStsVO> getDeleteList()
    {
        return _deleteList;
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
