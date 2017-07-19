package jp.co.isid.ham.media.model;

import java.io.Serializable;
import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * �c�ƍ�Ƒ䒠�����N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/07/16 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindAccountBookCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;


    /** �}�̊Ǘ�No */
    private List<String> _mediaPlanNo = null;

    /** �_�~�[ */
    private String _dummy = null;


    /**
     * �}�̊Ǘ�No���擾����
     *
     * @return �}�̊Ǘ�No
     */
    public List<String> getMediaPlanNo() {
        return _mediaPlanNo;
    }

    /**
     * �}�̊Ǘ�No��ݒ肷��
     *
     * @param mediaPnalNo �}�̊Ǘ�No
     */
    public void setMediaPlanNo(List<String> mediaPlanlNo) {
        _mediaPlanNo = mediaPlanlNo;
    }

    /**
     * �_�~�[���擾����
     *
     * @return �_�~�[
     */
    public String getDummy()
    {
        return _dummy;
    }

    /**
     * �_�~�[��ݒ肷��
     *
     * @param dummy �_�~�[
     */
    public void setDummy(String dummy)
    {
        _dummy = dummy;
    }

}
