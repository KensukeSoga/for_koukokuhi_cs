package jp.co.isid.ham.mastermaintenance.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;
import jp.co.isid.ham.common.model.Mbj48HmUserVO;
import jp.co.isid.ham.common.model.RegistExclusionVO;

/**
 * <P>
 * HM担当者登録データVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class RegistMbj48HmUserVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 排他ロック情報VO */
    RegistExclusionVO _exclusion;

    /** データVO追加リスト */
    private List<Mbj48HmUserVO> _insertList;

    /** データVO更新リスト */
    private List<Mbj48HmUserVO> _updateList;

    /** データVO削除リスト */
    private List<Mbj48HmUserVO> _deleteList;

    /**
     * デフォルトコンストラクタ
     */
    public RegistMbj48HmUserVO()
    {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new RegistMbj48HmUserVO();
    }

    /**
     * 排他ロック情報VOを設定する
     * @param vo セットする _exclusion
     */
    public void setExclusion(RegistExclusionVO vo) {
        _exclusion = vo;
    }

    /**
     * 排他ロック情報VOを取得する
     * @return _exclusion
     */
    public RegistExclusionVO getExclusion() {
        return _exclusion;
    }

    /**
     * データVO追加リストを設定する
     * @param voList List<Mbj48HmUserVO> データVO追加リスト
     */
    public void setInsertList(List<Mbj48HmUserVO> voList) {
        _insertList = voList;
    }

    /**
     * データVO追加リストを取得する
     * @return List<Mbj48HmUserVO> データVO追加リスト
     */
    public List<Mbj48HmUserVO> getInsertList() {
        return _insertList;
    }

    /**
     * データVO更新リストを設定する
     * @param voList List<Mbj48HmUserVO> データVO更新リスト
     */
    public void setUpdateList(List<Mbj48HmUserVO> voList) {
        _updateList = voList;
    }

    /**
     * データVO更新リストを取得する
     * @return List<Mbj48HmUserVO> データVO更新リスト
     */
    public List<Mbj48HmUserVO> getUpdateList() {
        return _updateList;
    }

    /**
     * データVO削除リストを設定する
     * @param voList List<Mbj48HmUserVO> データVO削除リスト
     */
    public void setDeleteList(List<Mbj48HmUserVO> voList) {
        _deleteList = voList;
    }

    /**
     * データVO削除リストを取得する
     * @return List<Mbj48HmUserVO> データVO削除リスト
     */
    public List<Mbj48HmUserVO> getDeleteList() {
        return _deleteList;
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
