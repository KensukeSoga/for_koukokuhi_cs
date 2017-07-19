package jp.co.isid.ham.common.model;


import java.util.List;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * �S���҃}�X�^Result
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/07/25 ���g)<BR>
 * </P>
 * @author ���g
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMbj02UserResult extends AbstractServiceResult {

    /** �S���҃}�X�^ */
    private List<Mbj02UserVO> _userVo;

    /**
     * �S���҃}�X�^VO���X�g���擾���܂�
     * @return �S���҃}�X�^VO
     */
    public List<Mbj02UserVO> getUserVo()
    {
        return _userVo;
    }

    /**
     * �S���҃}�X�^VO���X�g��ݒ肵�܂�
     * @param userVo �S���҃}�X�^
     */
    public void setUserVo(List<Mbj02UserVO> userVo)
    {
        _userVo = userVo;
    }


    /** List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ� */
    private String _dummy;

    /**
     * List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ����擾���܂�
     * @return String �_�~�[�v���p�e�B
     */
    public String getDummy()
    {
        return _dummy;
    }

    /**
     * List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ���ݒ肵�܂�
     * @param dummy �_�~�[�v���p�e�B
     */
    public void setDummy(String dummy)
    {
        this._dummy = dummy;
    }
}
